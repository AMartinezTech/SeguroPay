using AMartinezTech.Application.Insurance.Interfaces;

namespace AMartinezTech.Application.Insurance.UseCases.Read;

public class InsuranceGetById(IInsuranceReadRepository repository)
{
    private readonly IInsuranceReadRepository _repository = repository;

    public async Task<InsuranceDto> ExecuteAsync(Guid id)
    {
        var result = await _repository.GetById(id);
        return  InsuranceMapper.ToDto(result);
    }
}