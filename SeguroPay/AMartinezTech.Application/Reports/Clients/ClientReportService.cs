using System.Data;
using AMartinezTech.Application.Reports.Clients.Dtos;
using AMartinezTech.Application.Reports.Clients.Interfaces;

namespace AMartinezTech.Application.Reports.Clients;

public class ClientReportService(IClientReportRepository reportService) : IClientReportService
{
    private readonly IClientReportRepository _reportService = reportService;

    public async Task<DataTable> GetByFilterReportsAsync(Dictionary<string, object?>? filters = null)
    {
        return await _reportService.GetByFilterReportsAsync(filters); 
    }

    public async Task<IEnumerable<ReportClientTypeSummary>> TypeSummaryAsync()
    {
        var result = await _reportService.GetAllClientStatusAsync();

        var summary = new ClientTypeSummaryReport(result).Summary;

        return [.. summary
                .Select(x => new ReportClientTypeSummary
                {
                    ClientType = x.ClientType,
                    ActiveCount = x.ActiveCount,
                    InactiveCount = x.InactiveCount
                })];

    }
}
