using AMartinezTech.Domain.Insurance;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Insurances;

internal class MapToInsurance
{
    internal static InsuranceEntity ToEntity(SqlDataReader reader)
    {
        return InsuranceEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetDateTime(reader.GetOrdinal("created_at")),
            reader.GetString(reader.GetOrdinal("name")),
            reader.GetString(reader.GetOrdinal("address")),
            reader.GetString(reader.GetOrdinal("email")),
            reader.GetString(reader.GetOrdinal("phone")),
            reader.GetString(reader.GetOrdinal("contact_name")),
            reader.GetString(reader.GetOrdinal("contact_phone")),
            reader.GetBoolean(reader.GetOrdinal("is_active")));
    }
}
