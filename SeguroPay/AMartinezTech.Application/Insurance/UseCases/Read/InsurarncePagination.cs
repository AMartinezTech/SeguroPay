using AMartinezTech.Application.Insurance.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Insurance.UseCases.Read;

public class InsurarncePagination(IInsuranceReadRepository repository)
{
    private readonly IInsuranceReadRepository _repository = repository;

    public async Task<PageResult<InsuranceDto>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = InsuranceMapper.ToDtoList(result.Data);

        return new PageResult<InsuranceDto>(result.TotalRecords, pageSize, dtoList);
    }
}
