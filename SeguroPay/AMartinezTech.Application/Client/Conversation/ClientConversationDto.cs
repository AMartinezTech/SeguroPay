namespace AMartinezTech.Application.Client.Conversation;

public class ClientConversationDto
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public string Channel { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public Guid CreatedBy { get; set; }
}
