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
            var sql = @"INSERT INTO policies (id, policy_no, policy_type, insurance_id, clients_id, payment_frencuency, payment_method, payment_day, payment_installment, amount, note, status) VALUES(@Id, @PolicyNo, @PolicyType, @InsuranceId, @ClientId, @PaymentFrequency,  @PaymentMethod, @PaymentDay, @PaymentInstallment, @Amount, @Note, @Status)";

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", entity.Id); 
            cmd.Parameters.AddWithValue("@PolicyNo", entity.PolicyNo); 
            cmd.Parameters.AddWithValue("@PolicyType", entity.PolicyType.ToString()); 
            cmd.Parameters.AddWithValue("@InsuranceId", entity.InsuranceId); 
            cmd.Parameters.AddWithValue("@ClientId", entity.ClientId); 
            cmd.Parameters.AddWithValue("@PaymentFrequency", entity.PaymentFrequency.ToString()); 
            cmd.Parameters.AddWithValue("@PaymentMethod", entity.PaymentMethod.ToString());   
            cmd.Parameters.AddWithValue("@PaymentDay", entity.PaymentDay.Value); 
            cmd.Parameters.AddWithValue("@PaymentInstallment", entity.PaymentInstallment); 
            cmd.Parameters.AddWithValue("@Amount", entity.Amount); 
            cmd.Parameters.AddWithValue("@Note", entity.Note); 
            cmd.Parameters.AddWithValue("@Status", entity.Status.ToString());   

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
            var sql = @"UPDATE policies  SET policy_no = @PolicyNo, policy_type = @PolicyType, insurance_id = @InsuranceId, clients_id = @ClientId, payment_frencuency = @PaymentFrequency, payment_method = @PaymentMethod , payment_day = @PaymentDay, payment_installment = @PaymentInstallment, amount = @Amount, note = @Note, status = @Status WHERE id = @Id";

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.Parameters.AddWithValue("@PolicyNo", entity.PolicyNo);
            cmd.Parameters.AddWithValue("@PolicyType", entity.PolicyType.ToString());
            cmd.Parameters.AddWithValue("@InsuranceId", entity.InsuranceId);
            cmd.Parameters.AddWithValue("@ClientId", entity.ClientId);
            cmd.Parameters.AddWithValue("@PaymentFrequency", entity.PaymentFrequency.ToString());
            cmd.Parameters.AddWithValue("@PaymentMethod", entity.PaymentMethod.ToString());
            cmd.Parameters.AddWithValue("@PaymentDay", entity.PaymentDay.Value);
            cmd.Parameters.AddWithValue("@PaymentInstallment", entity.PaymentInstallment);
            cmd.Parameters.AddWithValue("@Amount", entity.Amount);
            cmd.Parameters.AddWithValue("@Note", entity.Note);
            cmd.Parameters.AddWithValue("@Status", entity.Status.ToString());
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
