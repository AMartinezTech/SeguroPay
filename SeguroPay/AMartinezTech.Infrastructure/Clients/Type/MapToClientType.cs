using AMartinezTech.Domain.Client.Entitties;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Clients.Type;

public class MapToClientType
{
    public static ClientTypeEntity ToEntity(SqlDataReader reader)
    {
        return ClientTypeEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetOrdinal("name").ToString(),
            bool.Parse(reader.GetOrdinal("is_actived").ToString())
            );
    }
}
