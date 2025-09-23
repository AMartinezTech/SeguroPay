using AMartinezTech.Application.Policy.Interfaces;

namespace AMartinezTech.Application.Policy.UseCases.Read;

public class PolicyFilter(IPolicyReadRepository repository)
{
    private readonly IPolicyReadRepository _repository = repository;

    public async Task<List<PolicyDto>> ExecuteAsync(string? filterStr, bool? isActived)
    {
        var result = await _repository.FilterAsync(filterStr, isActived);
        return PolicyMapper.ToDtoList(result);
    }
}