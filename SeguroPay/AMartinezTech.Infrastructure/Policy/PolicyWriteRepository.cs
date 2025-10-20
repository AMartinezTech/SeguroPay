using AMartinezTech.Application.Policy.Interfaces;
using AMartinezTech.Domain.Policy;
using AMartinezTech.Infrastructure.Utils.Persistence;

namespace AMartinezTech.Infrastructure.Policy;

public class PolicyWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), IPolicyWriteRepository
{
    public Task CreateAsync(PolicyEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(PolicyEntity entity)
    {
        throw new NotImplementedException();
    }
}
