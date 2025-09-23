using AMartinezTech.Application.Policy.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Policy.UseCases.Read;

public class PolicyGetByDate(IPolicyReadRepository repository)
{
    private readonly IPolicyReadRepository _repository = repository;

    public async Task<ByDateResult<PolicyDto>> ExecuteAsync(DateTime initialDate, DateTime endDate, bool? isActived)
    {
        var result = await _repository.GetByDateAsync(initialDate, endDate, isActived);
        var dtoList = PolicyMapper.ToDtoList(result.Data);

        return new ByDateResult<PolicyDto>(initialDate, endDate, dtoList);
    }
}
