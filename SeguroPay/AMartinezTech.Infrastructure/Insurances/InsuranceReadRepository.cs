using AMartinezTech.Application.Insurance.Interfaces; 
using AMartinezTech.Domain.Insurance;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exception;
using AMartinezTech.Infrastructure.Clients;
using AMartinezTech.Infrastructure.Data.Specifications;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Insurances;

public class InsuranceReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IInsuranceReadRepository
{
    public async Task<IReadOnlyList<InsuranceEntity>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? IsActive = null)
    {
        var result = new List<InsuranceEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };

            var spec = new SqlFilterSpecification(filters, globalSearch, IsActive);
            var whereClause = spec.BuildCondition(cmd);

            var sql = $"SELECT TOP 100 * FROM insurances {whereClause} ORDER BY name";
            cmd.CommandText = sql;

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                result.Add(MapToInsurance.ToEntity(reader));
        }
        return result;
    }

    public async Task<InsuranceEntity?> GetByIdAsync(Guid id)
    {
        try
        {
            InsuranceEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT *
                      FROM insurances WHERE id=@id";


            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToInsurance.ToEntity(reader);
            }

            if (entity == null) throw new DatabaseException($"{ErrorMessages.Get(ErrorType.RecordDoesDotExist)}"); ;


            return entity;


        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception) { throw; }
    }

    public async Task<PageResult<InsuranceEntity>> PaginationAsync(int pageNumber, int pageSize, bool? IsActive)
    {
        var result = new List<InsuranceEntity>();
        int totalRecords = 0;

        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // 1️⃣ Contar total de registros
            var countSql = "SELECT COUNT(*) FROM insurances WHERE 1=1";
            if (IsActive.HasValue)
                countSql += " AND is_active = @is_active";

            using (var countCmd = new SqlCommand(countSql, conn))
            {
                if (IsActive.HasValue)
                    countCmd.Parameters.AddWithValue("@is_active", IsActive.Value);

                totalRecords = Convert.ToInt32(await countCmd.ExecuteScalarAsync());
            }

            // 2️⃣ Traer página
            var sql = @"SELECT * 
                    FROM insurances
                    WHERE 1=1";

            if (IsActive.HasValue)
                sql += " AND is_active = @is_active";

            sql += @" ORDER BY name
                  OFFSET @offset ROWS 
                  FETCH NEXT @pageSize ROWS ONLY;";

            using var cmd = new SqlCommand(sql, conn);

            if (IsActive.HasValue)
                cmd.Parameters.AddWithValue("@is_active", IsActive.Value);

            cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
            cmd.Parameters.AddWithValue("@pageSize", pageSize);

            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
                result.Add(MapToInsurance.ToEntity(reader));
        }

        return new PageResult<InsuranceEntity>(totalRecords, pageSize, result);
    }
}
