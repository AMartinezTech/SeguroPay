namespace AMartinezTech.Application.Policy.DTOs;

public class PendingPaymentDto
{
    public Guid PolicyId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
}