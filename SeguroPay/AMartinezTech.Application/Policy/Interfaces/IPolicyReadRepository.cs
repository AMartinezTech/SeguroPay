using AMartinezTech.Domain.Policy;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Policy.Interfaces;

public interface IPolicyReadRepository : IPagination<PolicyEntity>, IGetByDate<PolicyEntity>, IGetById<PolicyEntity, Guid>, IFilter<PolicyEntity>;
