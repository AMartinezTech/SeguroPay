namespace AMartinezTech.Application.Policy.Payment;

public class PolicyPaymentDto
{
    public Guid Id { get; set; }
    public Guid PolicyId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string? Note { get; set; }
    public Guid CreatedBy { get; set; }
}
