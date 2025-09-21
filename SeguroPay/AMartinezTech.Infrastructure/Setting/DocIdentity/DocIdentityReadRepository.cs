using AMartinezTech.Application.Setting.DocIdentity;
using AMartinezTech.Core.Utils; 
using AMartinezTech.Domain.Setting.DocIndentity; 
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Setting.DocIdentity;

public class DocIdentityReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IDocIdentityReadRepository
{
    public async Task<PageResult<DocIdentityEntity>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = new List<DocIdentityEntity>();
        int totalRecords = 0;

        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // 1️⃣ Contar total de registros
            var countSql = "SELECT COUNT(*) FROM doc_identity_types WHERE 1=1";
            if (isActived.HasValue)
                countSql += " AND is_actived = @is_actived";

            using (var countCmd = new SqlCommand(countSql, conn))
            {
                if (isActived.HasValue)
                    countCmd.Parameters.AddWithValue("@is_actived", isActived.Value);

                totalRecords = (int)await countCmd.ExecuteScalarAsync();
            }

            // 2️⃣ Traer página
            var sql = @"doc_identity_types * 
                    FROM client_categories
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
                result.Add(MapToDocIdentity.ToEntity(reader));
        }

        return new PageResult<DocIdentityEntity>(totalRecords, pageSize, result);
    }
}
