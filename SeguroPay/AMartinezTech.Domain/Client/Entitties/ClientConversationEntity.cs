
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils.ValueObjects;
using AMartinezTech.Domain.Client.ValueObjects;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Domain.Client.Entitties;

public class ClientConversationEntity : IAggregateRoot
{

    public Guid Id { get; private set; }
    public ValueGuid ClientId { get; private set; }
    public ValueEnum<ChannelConvertationType> Channel { get; private set; } = ValueEnum<ChannelConvertationType>.Create("Teléfono");
    public ValuePhone ContactNumber { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ValueClientConversationSubject Subject { get; private set; }
    public ValueClientConversationMessage Message { get; private set; }
    public Guid CreatedBy { get; private set; }

    private ClientConversationEntity(Guid id, ValueGuid clientId, ValueEnum<ChannelConvertationType> channel, ValuePhone contactNumber, DateTime createdAt, ValueClientConversationSubject subject, ValueClientConversationMessage message, Guid createdBy)
    {
        Id = id;
        ClientId = clientId;
        Channel = channel;
        ContactNumber = contactNumber;
        CreatedAt = createdAt;
        Subject = subject;
        Message = message;
        CreatedBy = createdBy;
    }

    public static ClientConversationEntity Create(Guid id, Guid clientId, string channel, string contactNumber, DateTime createdAt, string subject, string message, Guid createdBy)
    {
        id = CreateGuid.EnsureId(id);
        return new ClientConversationEntity(id, ValueGuid.Create(clientId,"Client"), ValueEnum<ChannelConvertationType>.Create(channel), ValuePhone.Create(contactNumber, "Teléfono"), createdAt, ValueClientConversationSubject.Create(subject), ValueClientConversationMessage.Create(message), createdBy);
    }
}
