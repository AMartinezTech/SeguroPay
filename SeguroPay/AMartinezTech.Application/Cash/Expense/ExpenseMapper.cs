using AMartinezTech.Domain.Cash.Expense;

namespace AMartinezTech.Application.Cash.Expense;

internal class ExpenseMapper
{
    internal static ExpenseDto ToDto(ExpenseEntity entity)
    {
        return new ExpenseDto
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            CategoryId = entity.CategoryId.Value,
            Amount = entity.Amount.Value,
            Note = entity.Note ?? string.Empty,
            IsActived = entity.IsActived,
        };
    }

    internal static List<ExpenseDto> ToDtoList(IEnumerable<ExpenseEntity> entities) 
    {
        return [.. entities.Select(ToDto).ToList()];
    }
}
