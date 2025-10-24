using AMartinezTech.Domain.Client;

namespace AMartinezTech.Application.Client.Conversation;

internal class ClientConversationMapper
{
    internal static ClientConversationDto ToDto(ClientConversationEntity entity)
    {
        return new ClientConversationDto
        {
            Id = entity.Id,
            ClientId = entity.ClientId.Value,
            Channel = entity.Channel.Type.ToString(),
            ContactNumber = entity.ContactNumber.Value,
            CreatedAt = entity.CreatedAt,
            Subject = entity.Subject.Value,
            Message = entity.Message.Value,
            CreatedBy = entity.CreatedBy,
            CreatedByName = entity.CreatedByName ?? string.Empty,
        
        };
    }

    internal static List<ClientConversationDto> ToDtoList(IEnumerable<ClientConversationEntity> entities) 
    {
        return [.. entities.Select(ToDto).ToList()];
    
    }
}
