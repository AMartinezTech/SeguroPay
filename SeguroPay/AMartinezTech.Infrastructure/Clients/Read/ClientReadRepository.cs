using AMartinezTech.Application.Clients.Repositories;
using AMartinezTech.Core.Utils;
using AMartinezTech.Domain.Clients.Entitties;
using AMartinezTech.Infrastructure.Clients.Mappers;
using AMartinezTech.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Clients.Read;

public class ClientReadRepository(string conectionString) : AdoRepositoryBase(conectionString), IClientReadRepository
{
    public async Task<IReadOnlyList<ClientEntity>> FilterAsync(string? filterStr, bool? isActived)
    {
        var result = new List<ClientEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // Base query
            var sql = @"SELECT TOP 100 * FROM clients WHERE 1=1";

            if (isActived.HasValue)
                sql += " AND is_actived=@is_actived";

            if (!string.IsNullOrWhiteSpace(filterStr))
                sql += " AND (first_name LIKE @filter OR last_name LIKE @filter)";

            using var cmd = new SqlCommand(sql, conn);

            if (isActived.HasValue)
                cmd.Parameters.AddWithValue("@is_actived", isActived);

            if (!string.IsNullOrWhiteSpace(filterStr))
                cmd.Parameters.AddWithValue("@filter", $"%{filterStr}%");

            using var reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
                result.Add(MapToClient.ToEntity(reader));
        }
        return result;
    }

    public Task<ClientEntity> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResult<ClientEntity>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
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

                totalRecords = (int)await countCmd.ExecuteScalarAsync();
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

        return new PagedResult<ClientEntity>(totalRecords, pageSize, result);
    }
}
