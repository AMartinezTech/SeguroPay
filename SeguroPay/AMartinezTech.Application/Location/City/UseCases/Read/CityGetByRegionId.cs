using AMartinezTech.Application.Location.City.Interfaces;

namespace AMartinezTech.Application.Location.City.UseCases.Read;

public class CityGetByRegionId(ICityReadRepository repository)
{
    private readonly ICityReadRepository _repository = repository;

    public async Task<List<CityDto>> ExecuteAsync(Guid regionId)
    {
        var result = await _repository.GetByRegionId(regionId);
        return CityMapper.ToDtoList(result);
    }
}
