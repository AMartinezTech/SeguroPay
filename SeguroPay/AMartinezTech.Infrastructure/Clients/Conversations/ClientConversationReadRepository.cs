using AMartinezTech.Application.Client.Conversation.Interfaces;
using AMartinezTech.Domain.Client.Entitties;
using AMartinezTech.Domain.Utils.Exception;
using AMartinezTech.Infrastructure.Data.Specifications;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Clients.Conversations;

public class ClientConversationReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IClientConversationReadRepository
{
    public async Task<IReadOnlyList<ClientConversationEntity>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? IsActive = null)
    {
        var result = new List<ClientConversationEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };

            var spec = new SqlFilterSpecification(filters, globalSearch, IsActive);
            var whereClause = spec.BuildCondition(cmd);

           
            var sql = $@"
            SELECT 
                cc.id,
                cc.client_id,
                cc.channel,
                cc.contact_number,
                cc.created_at,
                cc.subject,
                cc.message,
                cc.created_by,
                u.full_name AS createdbyname
            FROM client_conversations cc
            INNER JOIN users u ON cc.created_by = u.id
            {whereClause}
            ORDER BY cc.created_at DESC;";
            cmd.CommandText = sql;

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                result.Add(MapToClientConversation.ToEntity(reader));
        }
        return result;
    }

    public async Task<ClientConversationEntity?> GetByIdAsync(Guid id)
    {
        try
        {
            ClientConversationEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            
            var sql = $@"
            SELECT 
                cc.id,
                cc.client_id,
                cc.channel,
                cc.contact_number,
                cc.created_at,
                cc.subject,
                cc.message,
                cc.created_by,
                u.full_name AS createdbyname
            FROM client_conversations cc
            INNER JOIN users u ON cc.created_by = u.id
            WHERE cc.id=@id
            ORDER BY cc.created_at DESC;";


            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToClientConversation.ToEntity(reader);
            }

            if (entity == null) throw new DatabaseException($"{ErrorMessages.Get(ErrorType.RecordDoesDotExist)}"); ;


            return entity;


        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception) { throw; }
    }
}
