using AMartinezTech.Application.Policy.Interfaces;
using AMartinezTech.Domain.Policy;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Policy;

public class PolicyWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), IPolicyWriteRepository
{
    public async Task CreateAsync(PolicyEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };
            var sql = @"INSERT INTO policies (id, policy_no, policy_type_id, insurance_id, client_id, pay_frencuency, pay_day, amount, note, status, created_by) VALUES(@id, @policy_no, @policy_type_id, @insurance_id, @client_id, @pay_frencuency, @pay_day, @amount, @note, @status, @created_by)";

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", entity.Id); 
            cmd.Parameters.AddWithValue("@policy_no", entity.PolicyNo); 
            cmd.Parameters.AddWithValue("@policy_type_id", entity.PolicyTypeId); 
            cmd.Parameters.AddWithValue("@insurance_id", entity.InsuranceId); 
            cmd.Parameters.AddWithValue("@client_id", entity.ClientId); 
            cmd.Parameters.AddWithValue("@pay_frencuency", entity.PayFrencuency.ToString()); 
            cmd.Parameters.AddWithValue("@pay_day", entity.PayDay); 
            cmd.Parameters.AddWithValue("@amount", entity.Amount); 
            cmd.Parameters.AddWithValue("@note", entity.Note); 
            cmd.Parameters.AddWithValue("@status", entity.Status.ToString()); 
            cmd.Parameters.AddWithValue("@createt_by", entity.CreatedBy);  

            await cmd.ExecuteNonQueryAsync();

        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex)
        {
            throw new DatabaseException("Error inesperado en infraestructura. Creando registro.!", ex);
        }
    }

    public async Task UpdateAsync(PolicyEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };
            var sql = @"UPDATE policies  SET policy_no = @policy_no, policy_type_id = @policy_type_id, insurance_id = @insurance_id, client_id = @client_id, pay_frencuency = @pay_frencuency, pay_day = @pay_day, amount = @amount, note = @note, status = @status, updated_at = @updated_at, active_by = @active_by, suspend_by = @suspend_by, cancel_by = @cancel_by WHERE id = @id";

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@policy_no", entity.PolicyNo);
            cmd.Parameters.AddWithValue("@policy_type_id", entity.PolicyTypeId);
            cmd.Parameters.AddWithValue("@insurance_id", entity.InsuranceId);
            cmd.Parameters.AddWithValue("@client_id", entity.ClientId);
            cmd.Parameters.AddWithValue("@pay_frencuency", entity.PayFrencuency.ToString());
            cmd.Parameters.AddWithValue("@pay_day", entity.PayDay);
            cmd.Parameters.AddWithValue("@amount", entity.Amount);
            cmd.Parameters.AddWithValue("@note", entity.Note);
            cmd.Parameters.AddWithValue("@status", entity.Status.ToString());
            cmd.Parameters.AddWithValue("@updated_at", entity.UpdatedAt);
            cmd.Parameters.AddWithValue("@active_by", entity.ActiveBy);
            cmd.Parameters.AddWithValue("@suspend_by", entity.SuspendBy);
            cmd.Parameters.AddWithValue("@cancel_by", entity.CreatedBy);

            await cmd.ExecuteNonQueryAsync();

        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex)
        {
            throw new DatabaseException("Error inesperado en infraestructura. actualizando registro.!", ex);
        }
    }
}
