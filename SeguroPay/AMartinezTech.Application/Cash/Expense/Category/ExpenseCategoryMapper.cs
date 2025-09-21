using AMartinezTech.Domain.Cash.Expense;

namespace AMartinezTech.Application.Cash.Expense.Category;

internal class ExpenseCategoryMapper
{
    internal static ExpenseCategoryDto ToDto(ExpenseCategoryEntity entity)
    {
        return new ExpenseCategoryDto
        {
            Id = entity.Id,
            Name = entity.Name,
            IsActived = entity.IsActived,
        };
    }

    internal static List<ExpenseCategoryDto> ToDtoList(IEnumerable<ExpenseCategoryEntity> entities) 
    {
        return [.. entities.Select(ToDto)];
    
    }
}
