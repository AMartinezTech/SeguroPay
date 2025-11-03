using AMartinezTech.Application.Client.Interfaces;
using AMartinezTech.Domain.Client;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exception;
using AMartinezTech.Infrastructure.Data.Specifications;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Clients;

public class ClientReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IClientReadRepository
{
    public async Task<IReadOnlyList<ClientEntity>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null,  Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null)
    {
        var result = new List<ClientEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };

            var spec = new SqlFilterSpecification(filters, globalSearch);
            var whereClause = spec.BuildCondition(cmd);

            var sql = $"SELECT * FROM clients {whereClause} ORDER BY created_at DESC, first_name, last_name";
            cmd.CommandText = sql;

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                result.Add(MapToClient.ToEntity(reader));
        }
        return result;
    }



    public async Task<ClientEntity?> GetByIdAsync(Guid id)
    {
        try
        {
            ClientEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT *
                      FROM clients WHERE id=@id";


            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToClient.ToEntity(reader);
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

    public async Task<PageResult<ClientEntity>> PaginationAsync(int pageNumber, int pageSize, bool? IsActive)
    {
        var result = new List<ClientEntity>();
        int totalRecords = 0;

        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // 1️⃣ Contar total de registros
            var countSql = "SELECT COUNT(*) FROM clients WHERE 1=1";
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
                    FROM clients
                    WHERE 1=1";

            if (IsActive.HasValue)
                sql += " AND is_active = @is_active";

            sql += @" ORDER BY first_name, last_name
                  OFFSET @offset ROWS 
                  FETCH NEXT @pageSize ROWS ONLY;";

            using var cmd = new SqlCommand(sql, conn);

            if (IsActive.HasValue)
                cmd.Parameters.AddWithValue("@is_active", IsActive.Value);

            cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
            cmd.Parameters.AddWithValue("@pageSize", pageSize);

            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
                result.Add(MapToClient.ToEntity(reader));
        }

        return new PageResult<ClientEntity>(totalRecords, pageSize, result);
    }
}
