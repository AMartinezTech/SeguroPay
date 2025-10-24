using AMartinezTech.Application.Reports.Policies.Dtos;
using AMartinezTech.Application.Reports.Policies.Interfaces;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Policy;

public class PolicyReportRepository(string connectionString) : AdoRepositoryBase(connectionString), IPolicyRepositoryReport
{
    public async Task<IReadOnlyList<PolicyStatusProjection>> GetAllPolicyStatusAsync()
    {
        var result = new List<PolicyStatusProjection>();
        using var conn = GetConnection();
        await conn.OpenAsync();

        using var cmd = new SqlCommand { Connection = conn };
        var sql = @"SELECT id, status FROM policies";

        cmd.CommandText = sql;

        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            result.Add(new PolicyStatusProjection
            {
                Status = reader.GetString(reader.GetOrdinal("status"))
            });

        }

        return result;
    }
}
