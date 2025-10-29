using AMartinezTech.Domain.Setting.Company;

namespace AMartinezTech.Application.Setting.Company;

internal class CompanyMapper
{
    internal static CompanyDto ToDto(CompanyEntity entity)
    {
        return new CompanyDto
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            RNC = entity.RNC.Value,
            Name = entity.Name.Value,
            Email = entity.Email.Value,
            Phone = entity.Phone.Value,
            Line1 = entity.Line1.Value,
            Line2 = entity.Line2.Value,
            IsActive = entity.IsActive,
            Logo = entity.Logo,
        };
    }

    internal static List<CompanyDto> ToDtoList(IEnumerable<CompanyEntity> entities)
    {
        return [.. entities.Select(ToDto)];

    }
}
