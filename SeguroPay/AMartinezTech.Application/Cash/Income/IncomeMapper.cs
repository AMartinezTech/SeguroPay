using AMartinezTech.Domain.Cash.Income;

namespace AMartinezTech.Application.Cash.Income;

internal class IncomeMapper
{
    internal static IncomeDto ToDto(IncomeEntity entity)
    {
        return new IncomeDto
        {
            Id = entity.Id,
            PaymentDate = entity.PaymentDate,
            CreatedAt = entity.CreatedAt,
            PolicyId = entity.PolicyId,
            ClientId = entity.ClientId,
            IncomeType  = entity.IncomeType.ToString(),
            PaymentMethod = entity.PaymentMethod.ToString(),
            MadeIn = entity.MadeIn.ToString(),
            CreatedBy = entity.CreatedBy,
            Amount = entity.Amount,
            Note = entity.Note,
            ClientName = entity.ClientName,
            TypeName = entity.TypeName,
        };
    }

    internal static List<IncomeDto> ToDtoList(IEnumerable<IncomeEntity> entities)
    {
        return [.. entities.Select(ToDto)];
    
    }
}
