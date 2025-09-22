using AMartinezTech.Domain.Location.Entities;

namespace AMartinezTech.Application.Location.Region;

internal class RegionMapper
{
    internal static RegionDto ToDto(RegionEntity entity)
    {
        return new RegionDto
        {
            Id = entity.Id,
            Name = entity.Name,
            CountryId = entity.CountryId,
            CreatedAt = entity.CreatedAt,
        };
    }

    internal static List<RegionDto> ToDtoList(IEnumerable<RegionEntity> entities)
    {
        return [.. entities.Select(ToDto).ToList()];

    }
}
