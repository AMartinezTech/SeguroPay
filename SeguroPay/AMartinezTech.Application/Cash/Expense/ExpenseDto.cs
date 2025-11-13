namespace AMartinezTech.Application.Cash.Expense;

public class ExpenseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Amount { get; set; }
    public string Note { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string IsActiveName => IsActive ? "Si" : "No";
    public Guid CreatedBy { get; set; }

}
