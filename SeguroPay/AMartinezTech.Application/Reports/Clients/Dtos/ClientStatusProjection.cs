namespace AMartinezTech.Application.Reports.Clients.Dtos;

public class ClientStatusProjection
{
    public string ClientType { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
