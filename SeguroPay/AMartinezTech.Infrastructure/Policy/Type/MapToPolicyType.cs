using AMartinezTech.Domain.Policy;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Policy.Type;

internal class MapToPolicyType
{
    internal static PolicyTypeEntity ToEntity(SqlDataReader reader)
    {
        return PolicyTypeEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("name")),
            reader.GetGuid(reader.GetOrdinal("insurance_id")),
            reader.GetBoolean(reader.GetOrdinal("is_active"))
            );
    }
}
