namespace AMartinezTech.Application.Cash.Income;

public class IncomeDto
{
    public Guid Id { get; set; }
    public DateTime PaymentDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid PolicyId { get;  set; }
    public Guid ClientId { get;  set; }
    public string IncomeType { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
    public string MadeIn { get; set; } = string.Empty;
    public Guid CreatedBy { get; set; }
    public decimal Amount { get; set; }
    public string? Note { get; set; } 
    public string? ClientName { get; set; }
    public string? TypeName { get; set; }
}
