using AMartinezTech.Application.Setting.Company;
using AMartinezTech.Domain.Setting.Company;
using AMartinezTech.Infrastructure.Utils.Persistence;

namespace AMartinezTech.Infrastructure.Setting.Company;

public class CompanyReadRepository(string connectionString) : AdoRepositoryBase(connectionString), ICompanyReadRepository
{
    public Task<IReadOnlyList<CompanyEntity>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? search = null, Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null)
    {
        throw new NotImplementedException();
    }

    public Task<CompanyEntity?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
