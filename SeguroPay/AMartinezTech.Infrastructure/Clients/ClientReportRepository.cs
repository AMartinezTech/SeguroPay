using AMartinezTech.Application.Reports.Clients;
using AMartinezTech.Domain.Client.Entitties;
using AMartinezTech.Infrastructure.Data.Specifications;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Clients;

public class ClientReportRepository(string connectionString) : AdoRepositoryBase(connectionString), IClientReportService
{
    public async Task<IReadOnlyList<ClientEntity>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? isActived = null)
    {
        var result = new List<ClientEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };

            var spec = new SqlFilterSpecification(filters, globalSearch, isActived);
            var whereClause = spec.BuildCondition(cmd);

            var sql = $"SELECT * FROM clients {whereClause} ORDER BY first_name, last_name";
            cmd.CommandText = sql;

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                result.Add(MapToClient.ToEntity(reader));
        }
        return result;
    }
}
