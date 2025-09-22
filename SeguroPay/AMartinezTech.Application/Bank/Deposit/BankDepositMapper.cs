using AMartinezTech.Domain.Bank.Deposit;

namespace AMartinezTech.Application.Bank.Deposit;

internal class BankDepositMapper
{
    internal static BankDepositDto ToDto(BankDepositEntity entity)
    {
        return new BankDepositDto
        {
            Id = entity.Id,
            Type = entity.Type.ToString(),
            BankAccountId = entity.BankAccountId.Value,
            Amount = entity.Amount.Value,
            Date = entity.Date,
            Reference = entity.Reference ?? string.Empty,
            Note = entity.Note ?? string.Empty,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy
        };
    }

    internal static List<BankDepositDto> ToDtoList(IEnumerable<BankDepositEntity> entities)
    {
        return [.. entities.Select(ToDto).ToList()];
    }
}
