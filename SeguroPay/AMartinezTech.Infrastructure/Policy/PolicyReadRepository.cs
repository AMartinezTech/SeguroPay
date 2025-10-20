using AMartinezTech.Application.Policy.Interfaces;
using AMartinezTech.Domain.Policy;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Infrastructure.Utils.Persistence;

namespace AMartinezTech.Infrastructure.Policy;

public class PolicyReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IPolicyReadRepository
{
    public Task<IReadOnlyList<PolicyEntity>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? search = null, bool? isActive = null)
    {
        throw new NotImplementedException();
    }

    public Task<bool> GetByClientIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ByDateResult<PolicyEntity>> GetByDateAsync(DateTime initialDate, DateTime endDate, bool? IsActive)
    {
        throw new NotImplementedException();
    }

    public Task<PolicyEntity?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
