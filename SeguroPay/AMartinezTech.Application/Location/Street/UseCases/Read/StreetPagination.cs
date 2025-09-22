using AMartinezTech.Application.Location.Street.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Location.Street.UseCases.Read;

public class StreetPagination(IStreetReadRepository repository)
{
    private readonly IStreetReadRepository _repository = repository;

    public async Task<PageResult<StreetDto>> ExecuteAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = StreetMapper.ToDtoList(result.Data);
        return new PageResult<StreetDto>(result.TotalRecords, pageSize, dtoList);
    }
}
