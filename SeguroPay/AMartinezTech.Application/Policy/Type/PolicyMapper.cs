using AMartinezTech.Domain.Policy;

namespace AMartinezTech.Application.Policy.Type;

internal class PolicyMapper
{
    internal static PolicyTypeDto ToDto(PolicyTypeEntity entity)
    {
        return new PolicyTypeDto
        {
            Id = entity.Id,
            Name = entity.Name.Value,
            InsuranceId = entity.InsuranceId.Value,
            IsActive = entity.IsActive,
        };
    }

    public static List<PolicyTypeDto> ToDtoList(IEnumerable<PolicyTypeEntity> entities) 
    {
        return [.. entities.Select(ToDto).ToList()];
    }
}
