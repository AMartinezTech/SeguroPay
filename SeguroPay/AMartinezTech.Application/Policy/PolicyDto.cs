using AMartinezTech.Application.Policy.Payment;

namespace AMartinezTech.Application.Policy;

public class PolicyDto
{
    public Guid Id { get; set; }
    public string PolicyNo { get; set; } = string.Empty;
    public Guid PolicyTypeId { get; set; }
    public Guid InsuranceId { get; set; }
    public Guid ClientId { get; set; }
    public string PayFrencuency { get; set; } = string.Empty;
    public int PayDay { get; set; }
    public decimal Amount { get; set; }
    public string? Note { get; set; }


    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Status { get; set; } = string.Empty;
    public Guid CreatedBy { get; set; }
    public Guid? ActiveBy { get; set; }
    public Guid? InactiveBy { get; set; }
    public Guid? SuspendBy { get; set; }
    public Guid? CancelBy { get; set; }

    public List<PolicyPaymentDto> PolicyPayments = [];
}
