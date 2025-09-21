using AMartinezTech.Application.Client.Types;
using AMartinezTech.Domain.Client.Entitties;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Clients.Type;

public class ClientTypeReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IClientTypeReadRepository
{
    public async Task<PageResult<ClientTypeEntity>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = new List<ClientTypeEntity>();
        int totalRecords = 0;

        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // 1️⃣ Contar total de registros
            var countSql = "SELECT COUNT(*) FROM client_types WHERE 1=1";
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
                    FROM client_types
                    WHERE 1=1";

            if (isActived.HasValue)
                sql += " AND is_actived = @is_actived";

            sql += @" ORDER BY name
                  OFFSET @offset ROWS 
                  FETCH NEXT @pageSize ROWS ONLY;";

            using var cmd = new SqlCommand(sql, conn);

            if (isActived.HasValue)
                cmd.Parameters.AddWithValue("@is_actived", isActived.Value);

            cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
            cmd.Parameters.AddWithValue("@pageSize", pageSize);

            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
                result.Add(MapToClientType.ToEntity(reader));
        }

        return new PageResult<ClientTypeEntity>(totalRecords, pageSize, result);
    }
}
