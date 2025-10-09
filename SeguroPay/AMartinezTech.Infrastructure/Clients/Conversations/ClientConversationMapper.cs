using AMartinezTech.Domain.Client.Entitties;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Clients.Conversations;

internal class ClientConversationMapper
{
    internal static ClientConversationEntity ToEntity(SqlDataReader reader)
    {
        return ClientConversationEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetGuid(reader.GetOrdinal("client_id")),
            reader.GetString(reader.GetOrdinal("channel")),
            reader.GetString(reader.GetOrdinal("contact_number")),
            reader.GetDateTime(reader.GetOrdinal("created_at")),
            reader.GetString(reader.GetOrdinal("subject")),
            reader.GetString(reader.GetOrdinal("message")),
            reader.GetGuid(reader.GetOrdinal("created_by"))
            );
    }
}
