using AMartinezTech.Domain.Location.Entities;

namespace AMartinezTech.Application.Location.Street;

internal class StreetMapper
{
    internal static StreetDto ToDto(StreetEntity entity)
    {
        return new StreetDto
        {
            Id = entity.Id,
            Name = entity.Name,
            CityId = entity.CityId.Value,
            CreatedAt = entity.CreatedAt,
        };
    }

    internal static List<StreetDto> ToDtoList(IEnumerable<StreetEntity> entities) 
    { 
    return [.. entities.Select(ToDto).ToList()];
    }
}
