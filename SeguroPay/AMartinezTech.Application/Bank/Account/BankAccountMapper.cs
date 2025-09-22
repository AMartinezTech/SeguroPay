using AMartinezTech.Domain.Bank.Account;

namespace AMartinezTech.Application.Bank.Account;

internal class BankAccountMapper
{
    internal static BankAccountDto ToDto(BankAccountEntity entity)
    {
        return new BankAccountDto
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            Name = entity.Name.Value,
            Number = entity.Number.Value,
            Type = entity.Type.ToString(),
            ContactName = entity.ContactName ?? string.Empty,
            ContactPhone = entity.ContactPhone ?? string.Empty,
            IsActived = entity.IsActived,
        };
    }

    internal static List<BankAccountDto> ToDtoList(IEnumerable<BankAccountEntity> entities) 
    {
        return [.. entities.Select(ToDto).ToList()];
    }
}
