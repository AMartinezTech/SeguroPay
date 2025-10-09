using AMartinezTech.Application.Client.Conversation.Interfaces;
using AMartinezTech.Domain.Client.Entitties;
using AMartinezTech.Infrastructure.Data.Specifications;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Clients.Conversations;

public class ClientConversationReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IClientConversationReadRepository
{
    public async Task<IReadOnlyList<ClientConversationEntity>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? isActived = null)
    {
        var result = new List<ClientConversationEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };

            var spec = new SqlFilterSpecification(filters, globalSearch, isActived);
            var whereClause = spec.BuildCondition(cmd);

            var sql = $"SELECT  * FROM client_conversations {whereClause} ORDER BY created_at";
            cmd.CommandText = sql;

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                result.Add(ClientConversationMapper.ToEntity(reader));
        }
        return result;
    }
}
