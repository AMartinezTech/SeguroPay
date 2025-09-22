using AMartinezTech.Application.Location.Country.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Location.Country.UseCases.Read;

public class CountryPagination(ICountryReadRepository repository )
{
    private readonly ICountryReadRepository _repository = repository;

    public async Task<PageResult<CountryDto>> ExecuteAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = CountryMapper.ToDtoList(result.Data);
        return new PageResult<CountryDto>(result.TotalRecords,pageSize, dtoList);
    }
}
