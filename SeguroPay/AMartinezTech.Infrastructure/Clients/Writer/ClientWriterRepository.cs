using AMartinezTech.Application.Clients.Repositories;
using AMartinezTech.Domain.Clients.Entitties;
using AMartinezTech.Infrastructure.Exceptions;
using AMartinezTech.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Clients.Writer;

public class ClientWriterRepository(string connectionString) : AdoRepositoryBase(connectionString), IClientWriteRepository
{
    public async Task CreateAsync(ClientEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            using var cmd = new SqlCommand("INSERT INTO clients (id, category_id, doc_identity_type_id, type_id, doc_identity, first_name, last_name, street_id, city_id, postal_code_id, region_id, country_id, phone, email, observation, location_no, address_ref) " +
                "VALUES (@id, @category_id, @doc_identity_type_id, @type_id, @doc_identity ,@first_name, @last_name, @street_id, @city_id, @postal_code_id, @region_id, @country_id, @phone, @email, @observation, @location_no, @address_ref)", conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@category_id", entity.CategoryId);
            cmd.Parameters.AddWithValue("@doc_identity_type_id", entity.DocIdentityTypeId);
            cmd.Parameters.AddWithValue("@type_id", entity.TypeId);
            cmd.Parameters.AddWithValue("@doc_identity", entity.DocIdentity);
            cmd.Parameters.AddWithValue("@first_name", entity.FirstName);
            cmd.Parameters.AddWithValue("@last_name", entity.LastName);
            cmd.Parameters.AddWithValue("@street_id", entity.StreetId);
            cmd.Parameters.AddWithValue("@postal_code_id", entity.PostalCodeId);
            cmd.Parameters.AddWithValue("@region_id", entity.RegionId);
            cmd.Parameters.AddWithValue("@country_id", entity.CountryId);
            cmd.Parameters.AddWithValue("@phone", entity.Phone);
            cmd.Parameters.AddWithValue("@email", entity.Email);
            cmd.Parameters.AddWithValue("@observation", entity.Observation);
            cmd.Parameters.AddWithValue("@location_no", entity.LocationNo);
            cmd.Parameters.AddWithValue("@address_ref", entity.AddressRef);

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
            using var cmd = new SqlCommand("DELETE FROM clients WHERE id=@id", conn);
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

            using var cmd = new SqlCommand("UPDATE clients  SET category_id=@category_id, doc_identity_type_id=@doc_identity_type_id, type_id=@type_id, doc_identity=@doc_identity, first_name=@first_name, last_name=@last_name, street_id=@street_id, city_id=@city_id, postal_code_id=@postal_code_id, region_id=@region_id, country_id=@country_id, phone=@phone, email=@email, observation=@observation, location_no=@location_no, address_ref=@address_ref, is_actived=@is_actived WHERE id=@id ", conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@category_id", entity.CategoryId);
            cmd.Parameters.AddWithValue("@doc_identity_type_id", entity.DocIdentityTypeId);
            cmd.Parameters.AddWithValue("@type_id", entity.TypeId);
            cmd.Parameters.AddWithValue("@doc_identity", entity.DocIdentity);
            cmd.Parameters.AddWithValue("@first_name", entity.FirstName);
            cmd.Parameters.AddWithValue("@last_name", entity.LastName);
            cmd.Parameters.AddWithValue("@street_id", entity.StreetId);
            cmd.Parameters.AddWithValue("@postal_code_id", entity.PostalCodeId);
            cmd.Parameters.AddWithValue("@region_id", entity.RegionId);
            cmd.Parameters.AddWithValue("@country_id", entity.CountryId);
            cmd.Parameters.AddWithValue("@phone", entity.Phone);
            cmd.Parameters.AddWithValue("@email", entity.Email);
            cmd.Parameters.AddWithValue("@observation", entity.Observation);
            cmd.Parameters.AddWithValue("@location_no", entity.LocationNo);
            cmd.Parameters.AddWithValue("@address_ref", entity.AddressRef);
            cmd.Parameters.AddWithValue("@is_actived", entity.IsActived);

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
