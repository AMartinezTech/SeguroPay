using System.Data;

namespace AMartinezTech.Application.Reports.Companies;

public interface ICompanyReportRepository
{
    Task<DataTable> GetByIdReportsAsync(Guid companyId);
}
