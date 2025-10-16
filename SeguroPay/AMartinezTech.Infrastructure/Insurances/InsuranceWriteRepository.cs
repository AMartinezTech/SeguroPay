using AMartinezTech.Application.Insurance.Interfaces;
using AMartinezTech.Domain.Insurance;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Insurances;

public class InsuranceWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), IInsuranceWriteRepository
{
    public async Task CreateAsync(InsuranceEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };

            var sql = @"INSERT INTO insurances (id, name, address, email, phone, contact_name, contact_phone, is_active) VALUES(@id, @name, @address, @email, @phone, @contact_name, @contact_phone, i@s_active)";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id",entity.Id);
            cmd.Parameters.AddWithValue("@name",entity.Name.Value);
            cmd.Parameters.AddWithValue("@address",entity.Address);
            cmd.Parameters.AddWithValue("@email",entity.Email);
            cmd.Parameters.AddWithValue("@phone",entity.Phone);
            cmd.Parameters.AddWithValue("@contact_name",entity.ContactName);
            cmd.Parameters.AddWithValue("@contact_phone",entity.ContactPhone);
            cmd.Parameters.AddWithValue("@is_active",entity.IsActived);


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

    public async Task UpdateAsync(InsuranceEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };

            var sql = @"UPDATE insurances SET name = @name, address = @address, email = @email, phone = @phone, contact_name = @contact_name, contact_phone = @contact_phone, is_active = @is_active WHERE id = @id";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@name", entity.Name.Value);
            cmd.Parameters.AddWithValue("@address", entity.Address);
            cmd.Parameters.AddWithValue("@email", entity.Email);
            cmd.Parameters.AddWithValue("@phone", entity.Phone);
            cmd.Parameters.AddWithValue("@contact_name", entity.ContactName);
            cmd.Parameters.AddWithValue("@contact_phone", entity.ContactPhone);
            cmd.Parameters.AddWithValue("@is_active", entity.IsActived);


            await cmd.ExecuteNonQueryAsync();
        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex) { throw new DatabaseException("Error inesperado en infraestructura. Actualizando registro.!", ex); }
    }
}
