using System.Data;

namespace AMartinezTech.Application.Reports.Incomes.Interfaces;

public interface IIncomeReportRepository
{
    Task<DataTable> GetIncomeReceiptAsync(Guid incomeId);

}
