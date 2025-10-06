using AMartinezTech.Application.Location.Street.Interfaces;
using AMartinezTech.Domain.Location.Entities;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Location.Street;

public class StreetWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), IStreetWriteRepository
{
    public async Task CreateAsync(StreetEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };

            var sql = @"INSERT INTO streets (id,street,city_id) VALUES(@id,@street,@city_id)";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@id",entity.Id);
            cmd.Parameters.AddWithValue("@street",entity.Name);
            cmd.Parameters.AddWithValue("@city_id",entity.CityId);

            await cmd.ExecuteNonQueryAsync();
        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex) { throw new DatabaseException("Error inesperado en infraestructura. Creando registro.!", ex); }
    }
    public async Task DeleteAsync(Guid id)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };

            var sql = @"DELETE FROM streets WHERE id=@id";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@id", id); 

            await cmd.ExecuteNonQueryAsync();
        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex) { throw new DatabaseException("Error inesperado en infraestructura. Creando registro.!", ex); }
    }

    public async Task UpdateAsync(StreetEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };

            var sql = @"UPDATE street SET street=@street, city_id=@city_id WHERE id=@id";

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@street", entity.Name);
            cmd.Parameters.AddWithValue("@city_id", entity.CityId);
            await cmd.ExecuteNonQueryAsync();
        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex) { throw new DatabaseException("Error inesperado en infraestructura. Creando registro.!", ex); }
    }
}
