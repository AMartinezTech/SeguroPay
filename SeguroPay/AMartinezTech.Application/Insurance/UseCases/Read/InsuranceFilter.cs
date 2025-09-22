using AMartinezTech.Application.Insurance.Interfaces;

namespace AMartinezTech.Application.Insurance.UseCases.Read;

public class InsuranceFilter(IInsuranceReadRepository repository)
{
    private readonly IInsuranceReadRepository _repository = repository;

    public async Task<List<InsuranceDto>> ExecuteAsync(string? filterStr, bool? isActived)
    {
        var result = await _repository.FilterAsync(filterStr, isActived);
        return InsuranceMapper.ToDtoList(result);
    }
}
