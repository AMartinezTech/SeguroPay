using AMartinezTech.Domain.Clients.Entitties;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Clients.Mappers;

public class MapToClient
{
    public static ClientEntity ToEntity(SqlDataReader reader)
    {
        return ClientEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetGuid(reader.GetOrdinal("category_id")),
            reader.GetGuid(reader.GetOrdinal("doc_identity_type_id")),
            reader.GetGuid(reader.GetOrdinal("type_id")),
            reader.GetOrdinal("doc_identity").ToString(),
            reader.GetOrdinal("first_name").ToString(),
            reader.GetOrdinal("last_name").ToString(),
            reader.GetGuid(reader.GetOrdinal("street_id")),
            reader.GetGuid(reader.GetOrdinal("city_id")),
            reader.GetGuid(reader.GetOrdinal("region_id")),
            reader.GetGuid(reader.GetOrdinal("postal_code_id")),
            reader.GetGuid(reader.GetOrdinal("country_id")),
            reader.GetOrdinal("phone").ToString(),
            reader.GetOrdinal("email").ToString(),
            reader.GetOrdinal("observation").ToString(),
            reader.GetOrdinal("location_no").ToString(),
            reader.GetOrdinal("address_ref").ToString(),
            bool.Parse(reader.GetOrdinal("is_actived").ToString())
            );
    }
}
