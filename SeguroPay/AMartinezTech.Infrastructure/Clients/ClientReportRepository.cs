using AMartinezTech.Application.Reports.Clients.Dtos;
using AMartinezTech.Application.Reports.Clients.Interfaces;
using AMartinezTech.Infrastructure.Data.Specifications;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;
using System.Data;

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
            while (await reader.ReadAsync())
            {
                result.Add(new ClientStatusProjection
                {
                    ClientType = reader.GetString(reader.GetOrdinal("client_type")),
                    IsActive = reader.GetBoolean(reader.GetOrdinal("is_active")),
                });
            }
        }
        return result;
    }

    public async Task<DataTable> GetByFilterReportsAsync(Dictionary<string, object?>? filters = null)
    {
        var dataTable = new DataTable("Clients");
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };

            var spec = new SqlFilterSpecification(filters);
            var whereClause = spec.BuildCondition(cmd);

            var sql = $@"SELECT c.id,
                        c.doc_identity_type,
                        c.client_type,
                        c.doc_identity,
                        c.first_name,
                        c.last_name, 
                        s.street AS street_name, 
                        ci.name AS city_name,
                        c.phone,
                        c.email,
                        c.observation,
                        c.location_no,
                        c.address_ref,
                        c.contact_name,
                        c.contact_phone,
                        c.is_active,
                        c.created_at
                        FROM clients as c
                        LEFT JOIN streets as s ON c.street_id = s.id
                        LEFT JOIN cities as ci ON c.city_id = ci.id
                        {whereClause} ORDER BY created_at DESC, first_name, last_name";
            cmd.CommandText = sql;

            using var adapter = new SqlDataAdapter(cmd);
            await Task.Run(() => adapter.Fill(dataTable));

        }
        return dataTable;
    }
}
