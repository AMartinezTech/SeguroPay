using AMartinezTech.Domain.Policy;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Policy.Interfaces;

public interface IPolicyReadRepository : IGetById<PolicyEntity, Guid>, IFilter<PolicyEntity>
{
   Task<bool> GetByClientIdAsync(Guid id);
}
