using AMartinezTech.Application.Policy.Interfaces;

namespace AMartinezTech.Application.Policy.UseCases.Read;

public class PolicyFilter(IPolicyReadRepository repository)
{
    private readonly IPolicyReadRepository _repository = repository;

    public async Task<List<PolicyDto>> ExecuteAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? IsActive = null)
    {
        var result = await _repository.FilterAsync(filters, globalSearch, IsActive);
        return PolicyMapper.ToDtoList(result);
    }
}