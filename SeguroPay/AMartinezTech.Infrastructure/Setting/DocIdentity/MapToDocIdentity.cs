using AMartinezTech.Domain.Settings.DocIndentity;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Setting.DocIdentity;

public class MapToDocIdentity
{
    public static DocIdentityEntity ToEntity(SqlDataReader reader)
    {
        return DocIdentityEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetOrdinal("name").ToString(),
            bool.Parse(reader.GetOrdinal("is_actived").ToString())
            );
    }
}
