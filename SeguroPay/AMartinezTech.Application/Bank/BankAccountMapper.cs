using AMartinezTech.Domain.Bank;

namespace AMartinezTech.Application.Bank;

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
            IsActive = entity.IsActive,
            Movements = [.. entity.Movements.Select(x => new BankAccountMovementDto
            {
                Id = x.Id,
                BankAccountId = x.BankAccountId,
                CreatedAt = x.CreatedAt,
                MovementTypes = x.MovementTypes.ToString(),
                Amount = x.Amount,
                Description = x.Description ?? string.Empty,
                CreatedBy = x.CreatedBy,
                CreatedByName = x.CreatedByName,
            })]
        };
    }

    internal static List<BankAccountDto> ToDtoList(IEnumerable<BankAccountEntity> entities) 
    {
        return [.. entities.Select(ToDto).ToList()];
    }
}
