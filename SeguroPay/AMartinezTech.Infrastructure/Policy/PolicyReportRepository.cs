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
         

        var sql = $@"SELECT TOP 500 
                p.id, 
                p.status, 
                (SELECT MAX(payment_date) FROM incomes WHERE policy_id=p.id) as last_payment  
                FROM policies p
                INNER JOIN insurances i ON p.insurance_id = i.id 
                INNER JOIN clients c ON p.clients_id = c.id 
                ORDER BY p.created_at DESC;";

        cmd.CommandText = sql;

        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            result.Add(new PolicyStatusProjection
            {
                Status = reader.GetString(reader.GetOrdinal("status")),
                LastPayment = reader.IsDBNull(reader.GetOrdinal("last_payment"))
                    ? null
                    : reader.GetDateTime(reader.GetOrdinal("last_payment"))
            });

        }

        return result;
    }
}
