
using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils.ValueObjects;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Domain.Policy;

public class PolicyEntity : IAggregateRoot
{
    public Guid Id { get; private set; }
    public string PolicyNo { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public Guid ClientId { get; private set; }
    public Guid InsuranceId { get; private set; }
    public Guid TypeId { get; private set; }
    public ValuePolicyPayDay PayDay { get; private set; }
    public PolicyPayFrencuency PayFrencuency { get; private set; } // Mensual, TrisMestral, Semestral, Anual
    public decimal Amount { get; private set; }
    public PolicyStatusType Status { get; private set; } = PolicyStatusType.Inactiva; // Activa, Suspendida, Cancelada, Inactiva
    public string? Note { get; private set; }
    public Guid CreatedBy { get; private set; }
    public Guid? ActivateBy { get; private set; }
    public Guid? SuspendBy { get; private set; }
    public Guid? CancelBy { get; private set; }

    private PolicyEntity(Guid id, string policyNo, DateTime createdAt, DateTime updatedAt, Guid clientId, Guid insuranceId, Guid typeId, ValuePolicyPayDay payDay, PolicyPayFrencuency payFrencuency, decimal amount, PolicyStatusType status, string? note, Guid createdBy, Guid? activateBy, Guid? suspendBy, Guid? cancelBy)
    {
        Id = id;
        PolicyNo = policyNo;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        ClientId = clientId;
        InsuranceId = insuranceId;
        TypeId = typeId;
        PayDay = payDay;
        PayFrencuency = payFrencuency;
        Amount = amount;
        Status = status;
        Note = note;
        CreatedBy = createdBy;
        ActivateBy = activateBy;
        SuspendBy = suspendBy;
        CancelBy = cancelBy;
    }

    public static PolicyEntity Create(Guid id, string policyNo, DateTime createdAt, DateTime updatedAt, Guid clientId, Guid insuranceId, Guid typeId, int payDay, PolicyPayFrencuency payFrencuency, decimal amount, PolicyStatusType status, string? note, Guid createdBy, Guid? activateBy, Guid? suspendBy, Guid? cancelBy)
    {


        id = CreateGuid.EnsureId(id);
        return new PolicyEntity(id, policyNo, createdAt, updatedAt, clientId, insuranceId, typeId, ValuePolicyPayDay.Create(payDay), payFrencuency, amount, status, note, createdBy, activateBy, suspendBy, cancelBy);

    }
}
