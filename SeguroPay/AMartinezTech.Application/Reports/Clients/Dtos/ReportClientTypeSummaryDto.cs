namespace AMartinezTech.Application.Reports.Clients.Dtos;

public class ReportClientTypeSummaryDto
{
    public string ClientType { get; set; } = string.Empty;
    public int ActiveCount { get; set; }
    public int InactiveCount { get; set; }
 }
