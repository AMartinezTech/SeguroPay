using AMartinezTech.Application.Policy.Payment;

namespace AMartinezTech.Application.Policy.DTOs;

public class PolicyDto
{
    public Guid Id { get; set; }
    public string PolicyNo { get; set; } = string.Empty;
    public string PolicyType { get; set; } = string.Empty;
    public Guid InsuranceId { get; set; }
    public string? InsuranceName { get; set; }
    public Guid ClientId { get; set; }
    public string? ClientName { get; set; }
    public string PaymentFrequency { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
    public int PaymentDay { get; set; }
    public int PaymentInstallment { get; set; }
    public decimal Amount { get; set; }
    public string? Note { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public List<PolicyPaymentDto> PolicyPayments = [];
}
