using AMartinezTech.Application.Bank;
using AMartinezTech.Domain.Bank;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Bank;

public class BankAccountWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), IBankAccountWriteRepository
{

    public async Task AddMovementAsync(BankAccountMovement movement)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };


            var sql = @"INSERT INTO bank_account_movements (id, bank_account_id, created_at, type, amount, description, created_by )  VALUES (@Id, @BankAccountId, @CreatedAt, @Type, @Amount, @Description, @CreatedBy )";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", movement.Id);
            cmd.Parameters.AddWithValue("@BankAccountId", movement.BankAccountId);
            cmd.Parameters.AddWithValue("@Type", movement.MovementTypes);
            cmd.Parameters.AddWithValue("@Amount", movement.Amount);
            cmd.Parameters.AddWithValue("@Description", movement.Description ?? string.Empty); 
            cmd.Parameters.AddWithValue("@CreatedBy", movement.CreatedBy);


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

    public async Task CreateAsync(BankAccountEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };


            var sql = @"INSERT INTO bank_accounts (id, name, number, type, contact_name, contact_phone, is_active)  VALUES (@Id, @Name, @Number, @Type, @ContactName, @ContactPhone, @IsActive)";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.Parameters.AddWithValue("@Name", entity.Name.Value);
            cmd.Parameters.AddWithValue("@Number", entity.Number.Value);
            cmd.Parameters.AddWithValue("@Type", entity.Type);
            cmd.Parameters.AddWithValue("@ContactName", entity.ContactName ?? string.Empty);
            cmd.Parameters.AddWithValue("@ContactPhone", entity.ContactPhone ?? string.Empty);
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


            var sql = @"DELETE FROM bank_accounts WHERE id = @Id";
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

    public async Task RemoveMovementAsync(Guid movementId)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };


            var sql = @"DELETE FROM bank_account_movements WHERE id = @Id";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", movementId);


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

    public async Task UpdateAsync(BankAccountEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };


            var sql = @"INSERT INTO bank_accounts SET name = @Name, number = @Number, type = @Type, contact_name = @ContactName, contact_phone = @ContactPhone, is_active = @IsActive WHERE id = @Id";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.Parameters.AddWithValue("@Name", entity.Name.Value);
            cmd.Parameters.AddWithValue("@Number", entity.Number.Value);
            cmd.Parameters.AddWithValue("@Type", entity.Type);
            cmd.Parameters.AddWithValue("@ContactName", entity.ContactName ?? string.Empty);
            cmd.Parameters.AddWithValue("@ContactPhone", entity.ContactPhone ?? string.Empty);
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
