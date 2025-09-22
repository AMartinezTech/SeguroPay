using AMartinezTech.Domain.Insurance;

namespace AMartinezTech.Application.Insurance;

internal class InsuranceMapper
{
    internal static InsuranceDto ToDto(InsuranceEntity entity)
    {
        return new InsuranceDto
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            Name = entity.Name.Value,
            CountryId = entity.Address.CountryId,
            RegionId = entity.Address.RegionId,
            CityId = entity.Address.CityId,
            StreetId = entity.Address.StreetId,
            Email = entity.Email.Value,
            Phone = entity.Phone.Value,
            ContactName = entity.ContactName ?? string.Empty,
            ContactPhone = entity.ContactPhone ?? string.Empty,
            IsActived = entity.IsActived,

        };
    }

    internal static List<InsuranceDto> ToDtoList(IEnumerable<InsuranceEntity> entities)
    {
        return [.. entities.Select(ToDto)];
    }
}
