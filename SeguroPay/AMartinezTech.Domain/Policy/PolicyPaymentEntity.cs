using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Policy;

public class PolicyPaymentEntity : IAggregateRoot
{
    public Guid Id { get; private set; }
    public ValueGuid PolicyId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime Date { get; private set; }
    public ValuePositiveNum Amount { get; private set; }
    public string? Note { get; private set; }
    public Guid CreatedBy { get; private set; }

    private PolicyPaymentEntity(Guid id, ValueGuid policyId, DateTime createdAt, DateTime date, ValuePositiveNum amount, string? note, Guid createdBy)
    {
        Id = id;
        PolicyId = policyId;
        CreatedAt = createdAt;
        Date = date;
        Amount = amount;
        Note = note;
        CreatedBy = createdBy;
    }

    public static PolicyPaymentEntity Create(Guid id, Guid policyId, DateTime createdAt, DateTime date, decimal amount, string? note, Guid createdBy)
    {
        id = CreateGuid.EnsureId(id);
        return new PolicyPaymentEntity(id, ValueGuid.Create(policyId,"póliza"), createdAt, date, ValuePositiveNum.Create(amount,"monto"), note, createdBy);
    }

}
