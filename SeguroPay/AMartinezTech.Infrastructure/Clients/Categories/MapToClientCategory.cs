using AMartinezTech.Domain.Clients.Entitties;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Clients.Categories;

public class MapToClientCategory
{
    public static ClientCategoryEntity ToEntity(SqlDataReader reader)
    {
        return ClientCategoryEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetOrdinal("name").ToString(),
            bool.Parse(reader.GetOrdinal("is_actived").ToString())
            );
    }
}
