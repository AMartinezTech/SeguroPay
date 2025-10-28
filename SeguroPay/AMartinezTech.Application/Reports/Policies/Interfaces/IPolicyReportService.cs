using AMartinezTech.Application.Reports.Policies.Dtos;

namespace AMartinezTech.Application.Reports.Policies.Interfaces;

public interface IPolicyReportService
{
    Task<PoplicySummaryByStatusReport> GetPolicyReportAsync();
}
