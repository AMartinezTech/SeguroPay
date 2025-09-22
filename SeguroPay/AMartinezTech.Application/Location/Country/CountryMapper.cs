using AMartinezTech.Domain.Location.Entities;

namespace AMartinezTech.Application.Location.Country;

internal class CountryMapper
{
    internal static CountryDto ToDto(CountryEntity entity)
    {
        return new CountryDto
        {
            Id = entity.Id,
            Name = entity.Name,
            CreatedAt = entity.CreatedAt,
        };
    }

    internal static List<CountryDto> ToDtoList(IEnumerable<CountryEntity> entities) 
    { 
        return [.. entities.Select(ToDto).ToList()];
    }
}
