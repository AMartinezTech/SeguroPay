using AMartinezTech.Application.Policy.Interfaces;

namespace AMartinezTech.Application.Policy.UseCases.Read;

public class PolicyGetById(IPolicyReadRepository repository)
{
    private readonly IPolicyReadRepository _repository = repository;

    public async Task<PolicyDto> ExecuteAsync(Guid id)
    {
        var result = await _repository.GetById(id);
        return PolicyMapper.ToDto(result);
    }
}
