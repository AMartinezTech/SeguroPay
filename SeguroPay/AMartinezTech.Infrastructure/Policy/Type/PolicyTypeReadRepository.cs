using AMartinezTech.Application.Policy.Type; 
using AMartinezTech.Domain.Policy;
using AMartinezTech.Domain.Utils.Exception; 
using AMartinezTech.Infrastructure.Data.Specifications;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Policy.Type;

public class PolicyTypeReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IPolicyTypeReadRepository
{
    public async Task<IReadOnlyList<PolicyTypeEntity>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? isActive = null)
    {
        var result = new List<PolicyTypeEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };

            var spec = new SqlFilterSpecification(filters, globalSearch, isActive);
            var whereClause = spec.BuildCondition(cmd);

            var sql = $"SELECT TOP 100 * FROM policy_types {whereClause} ORDER BY name";
            cmd.CommandText = sql;

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            result.Add(MapToPolicyType.ToEntity(reader));
        }
        return result;
    }

    public async Task<PolicyTypeEntity?> GetByIdAsync(Guid id)
    {
        try
        {
            PolicyTypeEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT *
                      FROM policy_types WHERE id=@id";


            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToPolicyType.ToEntity(reader);
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
}