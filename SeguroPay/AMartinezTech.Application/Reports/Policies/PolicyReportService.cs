using AMartinezTech.Application.Reports.Policies.Interfaces;
using AMartinezTech.Application.Utils.Interfaces;

namespace AMartinezTech.Application.Reports.Policies;

public class PolicyReportService(IPolicyRepositoryReport reportService, IServerTimeProvider serverTimeProvider) : IPolicyReportService
{
    private readonly IPolicyRepositoryReport _reportService = reportService;
    private readonly IServerTimeProvider _serverTimeProvider = serverTimeProvider;

    

    public async Task<PoplicySummaryByStatusReport> GetPolicyReportAsync()
    {
        var serverNow = await _serverTimeProvider.GetServerDateTimeAsync();
        var policies = await _reportService.GetAllPolicyStatusAsync();
        var report = new PoplicySummaryByStatusReport(policies, serverNow);
        return report;
    }
}
