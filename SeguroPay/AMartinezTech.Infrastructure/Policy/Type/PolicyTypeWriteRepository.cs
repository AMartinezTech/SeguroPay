using AMartinezTech.Application.Policy.Type;
using AMartinezTech.Domain.Policy;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Policy.Type;

public class PolicyTypeWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), IPolicyTypeWriteRepository
{
    public async Task CreateAsync(PolicyTypeEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };
            var sql = @"INSERT INTO policy_types (id, name, insurance_id, is_active) VALUES(@id, @name, @insurance_id, @is_active)";

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@name", entity.Name.Value);
            cmd.Parameters.AddWithValue("@insurance_id", entity.InsuranceId.Value);
            cmd.Parameters.AddWithValue("@is_active", entity.IsActive);

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


    public async Task UpdateAsync(PolicyTypeEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };
            var sql = @"UPDATE policy_types SET   name=@name, insurance_id=@insurance_id, is_active=@is_active WHERE id = @id";

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@name", entity.Name.Value);
            cmd.Parameters.AddWithValue("@insurance_id", entity.InsuranceId.Value   );
            cmd.Parameters.AddWithValue("@is_active", entity.IsActive);

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
}
