using AMartinezTech.Application.Reports.Incomes.Interfaces;
using System.Data;

namespace AMartinezTech.Application.Reports.Incomes;

public class IncomeReportService(IIncomeReportRepository reportRepository)
{
    public readonly IIncomeReportRepository _reportRepository = reportRepository;

    public Task<DataTable> GetReceiptAsync(Guid incomeId) 
        => _reportRepository.GetIncomeReceiptAsync(incomeId);
}
