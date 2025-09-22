using AMartinezTech.Application.Location.Region.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Location.Region.UseCases.Read;

public class RegionPagination(IRegionReadRepository repository)
{
    private readonly IRegionReadRepository _repository = repository;

    public async Task<PageResult<RegionDto>> ExecuteAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoLit = RegionMapper.ToDtoList(result.Data);
        return new PageResult<RegionDto>(result.TotalRecords, pageSize, dtoLit);
    }
}
