using AMartinezTech.Application.Reports.Clients.Dtos;
using System.Data;

namespace AMartinezTech.Application.Reports.Clients.Interfaces;

public interface IClientReportService
{
    Task<IEnumerable<ReportClientTypeSummary>> TypeSummaryAsync();

    Task<DataTable> GetByFilterReportsAsync(Dictionary<string, object?>? filters = null);
}
