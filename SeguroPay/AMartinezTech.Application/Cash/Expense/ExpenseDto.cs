using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Application.Cash.Expense;

public class ExpenseDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Amount { get; set; }
    public string Note { get; set; } = string.Empty;
    public bool IsActived { get; set; }
}
