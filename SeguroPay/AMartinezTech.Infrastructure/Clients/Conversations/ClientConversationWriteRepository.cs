using AMartinezTech.Application.Client.Conversation.Interfaces;
using AMartinezTech.Domain.Client.Entitties;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Clients.Conversations;

public class ClientConversationWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), IClientConversationWriteRepository
{
    public async Task CreateAsync(ClientConversationEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };

            var sql = @"INSERT INTO client_conversations (id, client_id, channel, contact_number, subject,message,created_by) VALUES(@id, @client_id, @channel, @contact_number, @subject,@message,@created_by)";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", entity.Id);   
            cmd.Parameters.AddWithValue("@client_id",entity.ClientId.Value);
            cmd.Parameters.AddWithValue("@channel", entity.Channel.Type.ToString());
            cmd.Parameters.AddWithValue("@contact_number", entity.ContactNumber.Value);
            cmd.Parameters.AddWithValue("@subject", entity.Subject.Value);
            cmd.Parameters.AddWithValue("@message", entity.Message.Value);
            cmd.Parameters.AddWithValue("@created_by", entity.CreatedBy); 

            await cmd.ExecuteNonQueryAsync();
        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex)
        {
            throw new DatabaseException("Error inesperado en infraestructura. Creando registro.!", ex);
        }
    }

    public async Task UpdateAsync(ClientConversationEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };

            var sql = @"UPDATE client_conversations SET channel=@channel, contact_number=@contact_number, subject=@subject, message=@message WHERE id=@id";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@channel", entity.Channel.Type.ToString());
            cmd.Parameters.AddWithValue("@contact_number", entity.ContactNumber.Value);
            cmd.Parameters.AddWithValue("@subject", entity.Subject.Value);
            cmd.Parameters.AddWithValue("@message", entity.Message.Value);

            await cmd.ExecuteNonQueryAsync();
        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex)
        {
            throw new DatabaseException("Error inesperado en infraestructura. Creando registro.!", ex);
        }
    }
}
