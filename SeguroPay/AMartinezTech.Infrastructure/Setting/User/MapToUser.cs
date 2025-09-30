using AMartinezTech.Domain.Setting.User;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Setting.User;

internal class MapToUser
{
    internal static UserEntity ToEntity(SqlDataReader reader)
    {
        return UserEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
             reader.GetString(reader.GetOrdinal("user_name")),
             reader.GetDateTime(reader.GetOrdinal("created_at")),
             reader.GetString(reader.GetOrdinal("email")),
             ValuePassword.FromHash(reader.GetString(reader.GetOrdinal("password"))),
             reader.GetString(reader.GetOrdinal("full_name")),
             reader.GetString(reader.GetOrdinal("phone")),
             reader.GetString(reader.GetOrdinal("rol")),
             reader.GetBoolean(reader.GetOrdinal("is_actived"))
            );
    }
}
