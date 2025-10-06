using AMartinezTech.Domain.Location.Entities;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Location.Street;

internal class MapToStreet
{
    internal static StreetEntity ToEntity(SqlDataReader reader)
    {
        return StreetEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetGuid(reader.GetOrdinal("city_id")),
            reader.GetString(reader.GetOrdinal("street")),
            reader.GetDateTime(reader.GetOrdinal("created_at")));
    }
}
