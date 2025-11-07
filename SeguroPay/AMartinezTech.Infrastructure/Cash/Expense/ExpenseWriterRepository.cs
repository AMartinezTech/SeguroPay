using AMartinezTech.Application.Cash.Expense.Interfaces;
using AMartinezTech.Domain.Cash.Expense;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Cash.Expense;

public class ExpenseWriterRepository(string connectionString) : AdoRepositoryBase(connectionString), IExpenseWriteRepository
{
    public async Task CreateAsync(ExpenseEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };


            var sql = @"INSERT INTO expenses (id, created_at, category_id, amount, note, is_active)  VALUES (@Id, @CreatedAt, @CategoryId, @Amount, @Note, @IsActive)";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt);
            cmd.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
            cmd.Parameters.AddWithValue("@Amount", entity.Amount);
            cmd.Parameters.AddWithValue("@Note", entity.Note ?? string.Empty);
            cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);

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


            var sql = @"DELETE FROM expenses  WHERE id = @Id";
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

    public async Task UpdateAsync(ExpenseEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };


            var sql = @"UPDATE expenses  SET category_id = @CategoryId, amount = @Amount, note = @Note, is_active = @IsActive WHERE id = @Id";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", entity.Id); 
            cmd.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
            cmd.Parameters.AddWithValue("@Amount", entity.Amount);
            cmd.Parameters.AddWithValue("@Note", entity.Note ?? string.Empty);
            cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);

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
