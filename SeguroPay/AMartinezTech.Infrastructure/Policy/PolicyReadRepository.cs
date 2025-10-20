using AMartinezTech.Application.Policy.Interfaces;
using AMartinezTech.Domain.Policy; 
using AMartinezTech.Domain.Utils.Exception;
using AMartinezTech.Infrastructure.Data.Specifications;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient; 

namespace AMartinezTech.Infrastructure.Policy;

public class PolicyReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IPolicyReadRepository
{
    public async Task<IReadOnlyList<PolicyEntity>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? search = null, bool? isActive = null, Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null)
    {
        var result = new List<PolicyEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };

            var spec = new SqlFilterSpecification(filters, search, isActive, dateRanges);
            var whereClause = spec.BuildCondition(cmd);

            var sql = $@"SELECT TOP 250
                        p.id,
                        p.policy_no,
                        pt.name AS policy_type_name,
                        i.name AS insurance_name,
                        CONCAT(c.first_name, ' ', c.last_name) AS client_name,
                        p.pay_frencuency,
                        p.pay_day,
                        p.amount,
                        p.note,
                        p.status,
                        p.created_at,
                        p.updated_at,
                        u_created.name AS created_by,
                        u_activated.name AS activated_by,
                        u_suspended.name AS suspended_by,
                        u_canceled.name AS canceled_by
                    FROM policies p
                    INNER JOIN policy_types pt ON p.policy_type_id = pt.id
                    INNER JOIN insurances i ON p.insurance_id = i.id
                    INNER JOIN clients c ON p.clients_id = c.id
                    LEFT JOIN users u_created ON p.created_by = u_created.id
                    LEFT JOIN users u_activated ON p.activate_by = u_activated.id
                    LEFT JOIN users u_suspended ON p.suspend_by = u_suspended.id
                    LEFT JOIN users u_canceled ON p.cancel_by = u_canceled.id;
                     {whereClause} ORDER BY p.created_at DESC;";
            cmd.CommandText = sql;

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                result.Add(MapToPolicy.ToEntity(reader));
        }
        return result;
    }

    public async Task<bool> GetByClientIdAsync(Guid id)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT COUNT(*) FROM policies WHERE clients_id = @id";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);

            var count = Convert.ToInt32(await cmd.ExecuteScalarAsync());

            return count > 0;
        }
        catch (SqlException ex)
        {
            var message = SqlErrorMapper.Map(ex);
            throw new DatabaseException(message);
        }
        catch (Exception)
        {
            throw;
        }
    } 

    public async Task<PolicyEntity?> GetByIdAsync(Guid id)
    {
        try
        {
            PolicyEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT *
                      FROM policies WHERE id=@id";


            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToPolicy.ToEntity(reader);
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
