using AMartinezTech.Domain.Client;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Clients;

internal class MapToClient
{
    internal static ClientEntity ToEntity(SqlDataReader reader)
    {
        return ClientEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("doc_identity_type")),
            reader.GetString(reader.GetOrdinal("client_type")),
            reader.GetString(reader.GetOrdinal("doc_identity")),
            reader.GetString(reader.GetOrdinal("first_name")),
            reader.GetString(reader.GetOrdinal("last_name")),
            reader.GetString(reader.GetOrdinal("phone")),
            reader.GetString(reader.GetOrdinal("email")),
            reader.GetString(reader.GetOrdinal("observation")),
            reader.GetString(reader.GetOrdinal("location_no")),
            reader.GetString(reader.GetOrdinal("address_ref")),
            reader.GetBoolean(reader.GetOrdinal("is_active")),
            reader.GetString(reader.GetOrdinal("contact_name")),
            reader.GetString(reader.GetOrdinal("contact_phone")),
            reader.GetGuid(reader.GetOrdinal("city_id")),
            reader.GetGuid(reader.GetOrdinal("street_id")) 
            );
    }
}
