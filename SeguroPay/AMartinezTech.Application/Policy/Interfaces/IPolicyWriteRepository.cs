using AMartinezTech.Domain.Policy;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Policy.Interfaces;

public interface IPolicyWriteRepository : ICreate<PolicyEntity>, IUpdate<PolicyEntity>;
