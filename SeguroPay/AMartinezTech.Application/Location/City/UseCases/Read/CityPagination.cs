using AMartinezTech.Application.Location.City.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Location.City.UseCases.Read;

public class CityPagination(ICityReadRepository repository)
{
    private readonly ICityReadRepository _repository = repository;

    public async Task<PageResult<CityDto>> ExecuteAsync(int pageNumber, int pageSize, bool? IsActive)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, IsActive);
        var dtoList = CityMapper.ToDtoList(result.Data);

        return new PageResult<CityDto>(result.TotalRecords, pageSize, dtoList);
    }
}
