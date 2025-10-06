using AMartinezTech.Domain.Location.Entities;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Location;

internal static class MapToCity
{
    internal static CityEntity ToEntity(SqlDataReader reader)
    {
        return CityEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("name")),
            reader.GetGuid(reader.GetOrdinal("region_id")),
            reader.GetDateTime(reader.GetOrdinal("created_at"))
            );
    }
}
