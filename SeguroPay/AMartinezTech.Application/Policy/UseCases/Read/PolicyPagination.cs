using AMartinezTech.Application.Policy.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Policy.UseCases.Read;

public class PolicyPagination(IPolicyReadRepository repository)
{
    private readonly IPolicyReadRepository _repository = repository;

    public async Task<PageResult<PolicyDto>> ExecuteAsync(int pageNumber, int pageSize, bool? IsActive)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, IsActive);
        var dtoList = PolicyMapper.ToDtoList(result.Data);

        return new PageResult<PolicyDto>(result.TotalRecords, pageSize, dtoList);
    }
}
