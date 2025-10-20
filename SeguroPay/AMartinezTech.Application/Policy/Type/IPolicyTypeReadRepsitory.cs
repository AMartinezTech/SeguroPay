using AMartinezTech.Domain.Policy;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Policy.Type;

public interface IPolicyTypeReadRepository : IFilter<PolicyTypeEntity>, IGetById<PolicyTypeEntity, Guid>;