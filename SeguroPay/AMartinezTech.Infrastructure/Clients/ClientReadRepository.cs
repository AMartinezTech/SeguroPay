using AMartinezTech.Application.Client.Interfaces;
using AMartinezTech.Domain.Client.Entitties;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Infrastructure.Data.Specifications;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Clients;

public class ClientReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IClientReadRepository
{
    public async Task<IReadOnlyList<ClientEntity>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? isActived = null)
    {
        var result = new List<ClientEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();


            var cmd = new SqlCommand { Connection = conn };

            var spec = new SqlFilterSpecification(filters, globalSearch, isActived);
            var whereClause = spec.BuildCondition(cmd);

            var sql = $"SELECT TOP 100 * FROM clients {whereClause} ORDER BY first_name, last_name";
            cmd.CommandText = sql;

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                result.Add(MapToClient.ToEntity(reader));
        }
        return result;
    }



    public Task<ClientEntity> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<PageResult<ClientEntity>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = new List<ClientEntity>();
        int totalRecords = 0;

        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // 1️⃣ Contar total de registros
            var countSql = "SELECT COUNT(*) FROM clients WHERE 1=1";
            if (isActived.HasValue)
                countSql += " AND is_actived = @is_actived";

            using (var countCmd = new SqlCommand(countSql, conn))
            {
                if (isActived.HasValue)
                    countCmd.Parameters.AddWithValue("@is_actived", isActived.Value);

                totalRecords = Convert.ToInt32(await countCmd.ExecuteScalarAsync());
            }

            // 2️⃣ Traer página
            var sql = @"SELECT * 
                    FROM clients
                    WHERE 1=1";

            if (isActived.HasValue)
                sql += " AND is_actived = @is_actived";

            sql += @" ORDER BY first_name, last_name
                  OFFSET @offset ROWS 
                  FETCH NEXT @pageSize ROWS ONLY;";

            using var cmd = new SqlCommand(sql, conn);

            if (isActived.HasValue)
                cmd.Parameters.AddWithValue("@is_actived", isActived.Value);

            cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
            cmd.Parameters.AddWithValue("@pageSize", pageSize);

            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
                result.Add(MapToClient.ToEntity(reader));
        }

        return new PageResult<ClientEntity>(totalRecords, pageSize, result);
    }
}
