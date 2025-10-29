using System.Data;

namespace AMartinezTech.Application.Reports.Companies;

public class CompanyReportService(ICompanyReportRepository companyReportRepository)
{
    private readonly ICompanyReportRepository _companyReportRepository = companyReportRepository;

    public async Task<DataTable> GetByIdAsync(  )
    {
        Guid companyId = Guid.Empty;
        return await _companyReportRepository.GetByIdReportsAsync(companyId);
    }
}
