using AMartinezTech.Application.Location.Region.Interfaces;

namespace AMartinezTech.Application.Location.Region.UseCases.Read;

public class RegionGetByCountryId(IRegionReadRepository repository)
{
    private readonly IRegionReadRepository _repository = repository;

    public async Task<List<RegionDto>> ExecuteAsync(Guid countryId)
    {
        var result = await _repository.GetByCountryId(countryId);
        return RegionMapper.ToDtoList(result);
    }
}
