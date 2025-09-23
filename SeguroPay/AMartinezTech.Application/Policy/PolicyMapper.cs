using AMartinezTech.Domain.Policy;

namespace AMartinezTech.Application.Policy;

internal class PolicyMapper
{
    internal static PolicyDto ToDto(PolicyEntity entity)
    {
        return new PolicyDto
        {
            Id = entity.Id,
            PolicyNo = entity.PolicyNo,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            ClientId = entity.ClientId.Value,
            InsuranceId = entity.InsuranceId.Value,
            TypeId = entity.TypeId.Value,
            PayDay = entity.PayDay.Value,
            PayFrencuency = entity.PayFrencuency.ToString(),
            Amount = entity.Amount,
            Status = entity.Status.ToString(),
            Note = entity.Note ?? string.Empty,
            CreatedBy = entity.CreatedBy,
            ActivateBy = entity.ActivateBy ?? Guid.Empty,
            SuspendBy = entity.SuspendBy ?? Guid.Empty, 
            CancelBy = entity.CancelBy ?? Guid.Empty,
        };
    }

    internal static List<PolicyDto> ToDtoList(IEnumerable<PolicyEntity> entities) 
    {
        return [.. entities.Select(ToDto).ToList()];
    }
}
