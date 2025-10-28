
namespace AMartinezTech.Application.Reports.Policies.Dtos;

public class PolicySummaryByStatus
{
    public string Status { get; set; } = string.Empty;
    public int Total { get; set; }
    public decimal Percentage { get; set; }

    public int ActivePendingCount { get; set; }
    public int ActiveOnTimeCount { get; set; }

    public decimal ActivePendingPercentage { get; set; }
    public decimal ActiveOnTimePercentage { get; set; }
}
