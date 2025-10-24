using AMartinezTech.Application.Reports.Clients.Dtos;

namespace AMartinezTech.Application.Reports.Clients.Interfaces;

public interface IClientReportService
{
    Task<IEnumerable<ReportClientTypeSummary>> TypeSummaryAsync();
}
