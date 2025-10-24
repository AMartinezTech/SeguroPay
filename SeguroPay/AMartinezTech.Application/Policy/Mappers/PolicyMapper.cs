using AMartinezTech.Application.Policy.DTOs;
using AMartinezTech.Domain.Policy;

namespace AMartinezTech.Application.Policy.Mappers;

internal class PolicyMapper
{
    internal static PolicyDto ToDto(PolicyEntity entity)
    {
        return new PolicyDto
        {
            Id = entity.Id,
            PolicyNo = entity.PolicyNo,
            PolicyType = entity.PolicyType.ToString(), 
            InsuranceId = entity.InsuranceId,
            InsuranceName = entity.InsuranceName,
            ClientId = entity.ClientId,
            ClientName = entity.ClientName,
            PaymentFrequency = entity.PaymentFrequency.ToString(),
            PaymentMethod = entity.PaymentMethod.ToString(),
            PaymentDay = entity.PaymentDay.Value,
            PaymentInstallment = entity.PaymentInstallment,
            Amount = entity.Amount,
            Note = entity.Note ?? string.Empty, 
            Status = entity.Status.ToString(),
            CreatedAt = entity.CreatedAt,
        };
    }

    internal static List<PolicyDto> ToDtoList(IEnumerable<PolicyEntity> entities)
    {
        return [.. entities.Select(ToDto).ToList()];
    }
}
