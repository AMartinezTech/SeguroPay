
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
    public ValueGuid ClientId { get; private set; }
    public ValueGuid EnsuranceId { get; private set; }
    public ValueGuid TypeId { get; private set; }
    public ValuePolicyPayDay PayDay { get; private set; }
    public ValueEnum<PolicyPayFrencuency> PayFrencuency { get; private set; } // Mensual, TrisMestral, Semestral, Anual
    public decimal Amount { get; private set; }
    public ValueEnum<PolicyStatusType> Status { get; private set; } = ValueEnum<PolicyStatusType>.Create("Inactiva");  // Activa, Suspendida, Cancelada, Inactiva
    public string? Note { get; private set; }
    public Guid CreatedBy { get; private set; }
    public Guid? ActivateBy { get; private set; }
    public Guid? SuspendBy { get; private set; }
    public Guid? CancelBy { get; private set; }

    private PolicyEntity(Guid id, string policyNo, DateTime createdAt, DateTime updatedAt, ValueGuid clientId, ValueGuid ensuranceId, ValueGuid typeId, ValuePolicyPayDay payDay, ValueEnum<PolicyPayFrencuency> payFrencuency, decimal amount, ValueEnum<PolicyStatusType> status, string? note, Guid createdBy, Guid? activateBy, Guid? suspendBy, Guid? cancelBy)
    {
        Id = id;
        PolicyNo = policyNo;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        ClientId = clientId;
        EnsuranceId = ensuranceId;
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

    public static PolicyEntity Create(Guid id, string policyNo, DateTime createdAt, DateTime updatedAt, Guid clientId, Guid ensuranceId, Guid typeId, int payDay, string payFrencuency, decimal amount, string status, string? note, Guid createdBy, Guid? activateBy, Guid? suspendBy, Guid? cancelBy)
    {


        id = CreateGuid.EnsureId(id);
        return new PolicyEntity(id, policyNo, createdAt, updatedAt, ValueGuid.Create(clientId,"cliente"), ValueGuid.Create(ensuranceId,"seguro"), ValueGuid.Create(typeId,"tipo"), ValuePolicyPayDay.Create(payDay), ValueEnum<PolicyPayFrencuency>.Create(payFrencuency), amount, ValueEnum<PolicyStatusType>.Create(status), note, createdBy, activateBy, suspendBy, cancelBy);

    }
}
