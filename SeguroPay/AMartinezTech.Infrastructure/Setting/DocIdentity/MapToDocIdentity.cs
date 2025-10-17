using AMartinezTech.Domain.Setting.DocIndentity;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Setting.DocIdentity;

internal class MapToDocIdentity
{
    public static DocIdentityEntity ToEntity(SqlDataReader reader)
    {
        return DocIdentityEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetOrdinal("name").ToString(),
            bool.Parse(reader.GetOrdinal("is_active").ToString())
            );
    }
}
