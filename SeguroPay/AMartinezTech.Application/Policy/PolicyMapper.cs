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
            PolicyTypeId = entity.PolicyTypeId,
            InsuranceId = entity.InsuranceId,
            ClientId = entity.ClientId,
            PayFrencuency = entity.PayFrencuency.ToString(),
            PayDay = entity.PayDay.Value,
            Amount = entity.Amount,
            Note = entity.Note ?? string.Empty,



            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            Status = entity.Status.ToString(),
            CreatedBy = entity.CreatedBy,
            ActiveBy = entity.ActiveBy ?? Guid.Empty,
            InactiveBy = entity.InactiveBy ?? Guid.Empty,
            SuspendBy = entity.SuspendBy ?? Guid.Empty, 
            CancelBy = entity.CancelBy ?? Guid.Empty,
        };
    }

    internal static List<PolicyDto> ToDtoList(IEnumerable<PolicyEntity> entities) 
    {
        return [.. entities.Select(ToDto).ToList()];
    }
}
