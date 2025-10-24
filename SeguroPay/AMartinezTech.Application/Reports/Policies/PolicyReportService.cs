using AMartinezTech.Application.Reports.Policies.Dtos;
using AMartinezTech.Application.Reports.Policies.Interfaces;

namespace AMartinezTech.Application.Reports.Policies;

public class PolicyReportService(IPolicyRepositoryReport reportService) : IPolicyReportService
{
    private readonly IPolicyRepositoryReport _reportService = reportService;

    public async Task<IEnumerable<PolicySummaryByStatus>> GetAllPolicyByStatusAsync()
    {
        var policies = await _reportService.GetAllPolicyStatusAsync();
        var report = new PoplicySummaryByStatusReport(policies);

        return report.Summary;
    }
}
