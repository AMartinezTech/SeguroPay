using AMartinezTech.Application.Location.City.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Location.City.UseCases.Read;

public class CityPagination(ICityReadRepository repository)
{
    private readonly ICityReadRepository _repository = repository;

    public async Task<PageResult<CityDto>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = CityMapper.ToDtoList(result.Data);

        return new PageResult<CityDto>(result.TotalRecords, pageSize, dtoList);
    }
}
