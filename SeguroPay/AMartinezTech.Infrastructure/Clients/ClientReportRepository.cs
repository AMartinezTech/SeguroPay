using AMartinezTech.Application.Reports.Clients.Dtos;
using AMartinezTech.Application.Reports.Clients.Interfaces; 
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Clients;

public class ClientReportRepository(string connectionString) : AdoRepositoryBase(connectionString), IClientReportRepository
{
    

    public async Task<IReadOnlyList<ClientStatusProjection>> GetAllClientStatusAsync()
    {
        var result = new List<ClientStatusProjection>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };

           

            var sql = $"SELECT client_type, is_active FROM clients ";
            cmd.CommandText = sql;

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync()){
                result.Add(new ClientStatusProjection
                {
                    ClientType = reader.GetString(reader.GetOrdinal("client_type")),
                    IsActive = reader.GetBoolean(reader.GetOrdinal("is_active")),
                });
            }
        }
        return result;
    }
}
