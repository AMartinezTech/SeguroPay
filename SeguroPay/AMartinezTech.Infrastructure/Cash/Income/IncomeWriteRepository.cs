using AMartinezTech.Application.Cash.Income;
using AMartinezTech.Domain.Cash.Income;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Cash.Income;

public class IncomeWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), IIncomeWriteRepository
{
    public async Task CreateAsync(IncomeEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };


            var sql = @"INSERT INTO incomes (id, payment_date, policy_id, client_id, income_type, payment_method, made_in, created_by, amount, note) " +
                "VALUES (@id, @PaymentDate, @PolicyId, @ClientId, @IncomeType, @PaymentMethod, @MadeIn, @CreatedBy, @Amount, @Note)";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@PaymentDate", entity.PaymentDate );
            cmd.Parameters.AddWithValue("@PolicyId", entity.PolicyId);
            cmd.Parameters.AddWithValue("@ClientId", entity.ClientId);
            cmd.Parameters.AddWithValue("@IncomeType", entity.IncomeType.ToString());
            cmd.Parameters.AddWithValue("@PaymentMethod", entity.PaymentMethod.ToString());
            cmd.Parameters.AddWithValue("@MadeIn", entity.MadeIn.ToString());
            cmd.Parameters.AddWithValue("@CreatedBy", entity.CreatedBy);
            cmd.Parameters.AddWithValue("@Amount", entity.Amount);
            cmd.Parameters.AddWithValue("@Note", entity.Note); 

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

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };


            var sql = @"DELETE FROM incomes WHERE id = @Id";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", id);
            

            await cmd.ExecuteNonQueryAsync();

        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex)
        {
            throw new DatabaseException("Error inesperado en infraestructura. Borrando registro.!", ex);
        }
    }

    public async Task UpdateAsync(IncomeEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };

            var sql = @"UPDATE incomes SET  payment_method = @PaymentMethod, made_in = @MadeIn, note = @Note WHERE id = @Id";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", entity.Id); 
            cmd.Parameters.AddWithValue("@PaymentMethod", entity.PaymentMethod.ToString());
            cmd.Parameters.AddWithValue("@MadeIn", entity.MadeIn.ToString()); 
            cmd.Parameters.AddWithValue("@Note", entity.Note);

            await cmd.ExecuteNonQueryAsync();

        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex)
        {
            throw new DatabaseException("Error inesperado en infraestructura. Actualizando registro.!", ex);
        }
    }
}
