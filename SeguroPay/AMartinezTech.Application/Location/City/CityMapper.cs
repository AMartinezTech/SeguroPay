using AMartinezTech.Domain.Location.Entities;

namespace AMartinezTech.Application.Location.City;

internal class CityMapper
{
    internal static CityDto ToDto(CityEntity entity)
    {
        return new CityDto
        {
            Id = entity.Id,
            Name = entity.Name,
            RegionId = entity.RegionId,
            CreatedAt = entity.CreatedAt,
        };
    }

    internal static List<CityDto> ToDtoList(IEnumerable<CityEntity> entities) 
    {
        return [.. entities.Select(ToDto).ToList()];
    }
}
