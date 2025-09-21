namespace AMartinezTech.Application.Cash.Expense.Category;

public class ExpenseCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActived { get; set; }
}
