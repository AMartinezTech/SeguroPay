using AMartinezTech.Domain.Reports.Clients;
using AMartinezTech.Application.Reports.Clients.Dtos;

namespace AMartinezTech.Application.Reports.Clients;

public class ClientReportService(IClientReportService reportService)
{
    private readonly IClientReportService _reportService = reportService;

    public async Task<IEnumerable<ReportClientTypeSummaryDto>> TypeSummaryAsync()
    {
        var result = await _reportService.FilterAsync();

        var summary = new ClientTypeSummaryReport(result).Summary;

        return summary 
    .Select(x => new ReportClientTypeSummaryDto
    {
        ClientType = x.ClientType,
        ActiveCount = x.ActiveCount,
        InactiveCount = x.InactiveCount
    })
    .ToList();

    }
}
