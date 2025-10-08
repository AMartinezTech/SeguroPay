namespace AMartinezTech.Domain.Reports.Clients;

public class ClientTypeSummary
{
    public string ClientType { get; set; } = string.Empty;
    public int ActiveCount { get; set; }
    public int InactiveCount { get; set; }
}
