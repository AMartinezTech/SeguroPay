using AMartinezTech.Application.Client.Interfaces;
using AMartinezTech.Domain.Client;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Clients;

public class ClientWriterRepository(string connectionString) : AdoRepositoryBase(connectionString), IClientWriteRepository
{
    public async Task CreateAsync(ClientEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };


            var sql = @"INSERT INTO clients (id, doc_identity_type, client_type, doc_identity, first_name, last_name, street_id, city_id, phone, email, observation, location_no, address_ref, contact_name, contact_phone) " +
                "VALUES (@id, @doc_identity_type, @client_type, @doc_identity ,@first_name, @last_name, @street_id, @city_id, @phone, @email, @observation, @location_no, @address_ref, @contact_name, @contact_phone)";
            cmd.CommandText = sql;  
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@doc_identity_type", entity.DocIdentityType.ToString());
            cmd.Parameters.AddWithValue("@client_type", entity.ClientType.ToString());
            cmd.Parameters.AddWithValue("@doc_identity", entity.DocIdentity);
            cmd.Parameters.AddWithValue("@first_name", entity.FirstName.Value);
            cmd.Parameters.AddWithValue("@last_name", entity.LastName.Value);
            cmd.Parameters.AddWithValue("@street_id", entity.StreetId.Value);
            cmd.Parameters.AddWithValue("@city_id", entity.CityId.Value);
            cmd.Parameters.AddWithValue("@phone", entity.Phone);
            cmd.Parameters.AddWithValue("@email", entity.Email.Value);
            cmd.Parameters.AddWithValue("@observation", entity.Observation);
            cmd.Parameters.AddWithValue("@location_no", entity.LocationNo);
            cmd.Parameters.AddWithValue("@address_ref", entity.AddressRef);
            cmd.Parameters.AddWithValue("@contact_name", entity.ContactName);
            cmd.Parameters.AddWithValue("@contact_phone", entity.ContactPhone);

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
            var sql =@"DELETE FROM clients WHERE id=@id";
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@id", id);
            await cmd.ExecuteNonQueryAsync();


        }
        catch (SqlException ex)
        {

            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex) { throw new DatabaseException("Error inesperado en infraestructura. Borrando registro.!", ex); }

    }
     
    public async Task UpdateAsync(ClientEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection= conn };

            var sql = @"UPDATE clients  SET doc_identity_type=@doc_identity_type, client_type=@client_type, doc_identity=@doc_identity, first_name=@first_name, last_name=@last_name, street_id=@street_id, city_id=@city_id, phone=@phone, email=@email, observation=@observation, location_no=@location_no, address_ref=@address_ref, is_active=@is_active, contact_name=@contact_name, contact_phone=@contact_phone WHERE id=@id ";
            cmd.CommandText= sql;
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@doc_identity_type", entity.DocIdentityType.ToString());
            cmd.Parameters.AddWithValue("@client_type", entity.ClientType.ToString());
            cmd.Parameters.AddWithValue("@doc_identity", entity.DocIdentity);
            cmd.Parameters.AddWithValue("@first_name", entity.FirstName.Value);
            cmd.Parameters.AddWithValue("@last_name", entity.LastName.Value);
            cmd.Parameters.AddWithValue("@street_id", entity.StreetId.Value);
            cmd.Parameters.AddWithValue("@city_id", entity.CityId.Value);
            cmd.Parameters.AddWithValue("@phone", entity.Phone);
            cmd.Parameters.AddWithValue("@email", entity.Email.Value);
            cmd.Parameters.AddWithValue("@observation", entity.Observation);
            cmd.Parameters.AddWithValue("@location_no", entity.LocationNo);
            cmd.Parameters.AddWithValue("@address_ref", entity.AddressRef);
            cmd.Parameters.AddWithValue("@contact_name", entity.ContactName);
            cmd.Parameters.AddWithValue("@contact_phone", entity.ContactPhone);
            cmd.Parameters.AddWithValue("@is_active", entity.IsActive);

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
