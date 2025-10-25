namespace AMartinezTech.Application.Cash.Income;

public class IncomeDto
{
    public Guid Id { get; set; }
    public DateTime PaymentDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid DocIdRelated { get; set; }
    public string IncomeType { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
    public string MadeIn { get; set; } = string.Empty;
    public Guid CreatedBy { get; set; }
    public decimal Amount { get; set; }
}
