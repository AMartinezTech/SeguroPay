using AMartinezTech.Application.Reports.Policies.Dtos;

namespace AMartinezTech.Application.Reports.Policies.Interfaces;

public interface IPolicyRepositoryReport
{
    Task<IReadOnlyList<PolicyStatusProjection>> GetAllPolicyStatusAsync();
}
