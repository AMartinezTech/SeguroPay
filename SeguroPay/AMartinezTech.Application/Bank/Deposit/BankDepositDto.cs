namespace AMartinezTech.Application.Bank.Deposit;

public class BankDepositDto
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public Guid BankAccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string? Reference { get; set; }
    public string? Note { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
}
