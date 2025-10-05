using AMartinezTech.Application.Insurance.Interfaces;

namespace AMartinezTech.Application.Insurance.UseCases.Read;

public class InsuranceFilter(IInsuranceReadRepository repository)
{
    private readonly IInsuranceReadRepository _repository = repository;

    public async Task<List<InsuranceDto>> ExecuteAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? isActived = null)
    {
        var result = await _repository.FilterAsync(filters, globalSearch, isActived);
        return InsuranceMapper.ToDtoList(result);
    }
}
