using AMartinezTech.Domain.Policy;

namespace AMartinezTech.Application.Policy.Payment;

internal class PolicyPaymentMapper
{
    internal static PolicyPaymentDto ToDto(PolicyPaymentEntity entity)
    {
        return new PolicyPaymentDto
        {
            Id = entity.Id,
            PolicyId = entity.PolicyId.Value,
            CreatedAt = entity.CreatedAt,
            Date = entity.Date,
            Amount = entity.Amount.Value,
            Note = entity.Note ?? string.Empty,
            CreatedBy = entity.CreatedBy,
        };
    }

    internal static List<PolicyPaymentDto> ToDtoList(IEnumerable<PolicyPaymentEntity> entities) 
    {
        return [.. entities.Select(ToDto).ToList()];
    }
}
