namespace AMartinezTech.Application.Policy;

public class PolicyDto
{
    public Guid Id { get;  set; }
    public string PolicyNo { get; set; } = string.Empty;
    public DateTime CreatedAt { get;  set; }
    public DateTime UpdatedAt { get;  set; }
    public Guid ClientId { get;  set; }
    public Guid InsuranceId { get;  set; }
    public Guid TypeId { get;  set; }
    public int PayDay { get;  set; }
    public string PayFrencuency { get;  set; } = string.Empty;
    public decimal Amount { get;  set; }
    public string Status { get; set; } = string.Empty;
    public string? Note { get;  set; }
    public Guid CreatedBy { get;  set; }
    public Guid? ActivateBy { get;  set; }
    public Guid? SuspendBy { get;  set; }
    public Guid? CancelBy { get;  set; }
}
