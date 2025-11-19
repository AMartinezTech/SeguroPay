namespace AMartinezTech.Application.Bank;

public class BankAccountMovementDto
{
    public Guid Id { get;  set; }
    public Guid BankAccountId { get;  set; }
    public DateTime CreatedAt { get;  set; }
    public string MovementTypes { get;  set; } = string.Empty;
    public decimal Amount { get;  set; }
    public string? Description { get;  set; }
    public Guid CreatedBy { get; set; }
    public string? CreatedByName { get; set; } = string.Empty ;
}
