using AMartinezTech.Domain.Utils.Interfaces; 
using AMartinezTech.Domain.Utils.Enums; 
using AMartinezTech.Domain.Utils.Exception;

namespace AMartinezTech.Domain.Policy;

public class PolicyEntity : IAggregateRoot
{

    public Guid Id { get; private set; } = Guid.NewGuid();
    public string PolicyNo { get; private set; }
    public Guid PolicyTypeId { get; private set; }
    public string? PolicyTypeName { get; private set; }
    public Guid InsuranceId { get; private set; }
    public string? InsuranceName { get; private set; }
    public Guid ClientId { get; private set; }
    public string? ClientName { get; private set; }
    public PolicyPayFrencuency PayFrencuency { get; private set; } = PolicyPayFrencuency.Monthly; // Monthly, Quarterly, Semiannual, Annual
    public ValuePolicyPayDay PayDay { get; private set; }
    public decimal Amount { get; private set; }
    public string? Note { get; private set; }


    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public PolicyStatusType Status { get; private set; } = PolicyStatusType.Inactive; // Active, Suspended, Canceled, Inactive
    public Guid CreatedBy { get; private set; }
    public Guid? ActiveBy { get; private set; } = Guid.Empty;
    public Guid? InactiveBy { get; private set; } = Guid.Empty;
    public Guid? SuspendBy { get; private set; } = Guid.Empty;
    public Guid? CancelBy { get; private set; } = Guid.Empty;

    private readonly List<PolicyPaymentEntity> _policyPayments = [];
    public IReadOnlyCollection<PolicyPaymentEntity> PolicyPayments => _policyPayments.AsReadOnly();

    private PolicyEntity(string policyNo, Guid policyTypeId, Guid insuranceId, Guid clientId, PolicyPayFrencuency payFrencuency, ValuePolicyPayDay payDay, decimal amount, string? note, DateTime createdAt, DateTime updatedAt, PolicyStatusType status, Guid createdBy, string? policyTypeName , string? insuranceName, string? clientName)
    {
        PolicyNo = policyNo;
        PolicyTypeId = policyTypeId;
        InsuranceId = insuranceId;
        ClientId = clientId;
        PayFrencuency = payFrencuency;
        PayDay = payDay;
        Amount = amount;
        Note = note;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Status = status;
        CreatedBy = createdBy;
        Validate();
        PolicyTypeName = policyTypeName;
        InsuranceName = insuranceName;
        ClientName = clientName;
    }
    public static PolicyEntity Create(string policyNo, Guid policyTypeId, Guid insuranceId, Guid clientId, PolicyPayFrencuency payFrencuency, int payDay, decimal amount, string? note, DateTime createdAt, DateTime updatedAt, PolicyStatusType status, Guid createdBy, string? policyTypeName = null, string? insuranceName = null, string? clientName = null)
    {  
        return new PolicyEntity(policyNo, policyTypeId, insuranceId, clientId, payFrencuency, ValuePolicyPayDay.Create(payDay), amount, note, createdAt, updatedAt, status, createdBy, policyTypeName, insuranceName, clientName); 
    }
    public void UpdatePolicy(
     string policyNo, Guid policyTypeId, Guid insuranceId, PolicyPayFrencuency payFrencuency,
     int payDay, decimal amount, string? note )
    {
        if (_policyPayments.Count != 0)
            throw new Exception($"{ErrorMessages.Get(ErrorType.HasMomevements)}");

        if (Status != PolicyStatusType.Active)
            throw new Exception("Solo se puede modificar una póliza activa.");
         
        PolicyNo = policyNo;
        PolicyTypeId = policyTypeId;
        InsuranceId = insuranceId;
        PayFrencuency = payFrencuency;
        PayDay = ValuePolicyPayDay.Create(payDay);
        Amount = amount;
        Note = note;
        Validate();
    }
    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(PolicyNo)) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - PolicyNo");

        if (PolicyTypeId == Guid.Empty) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - PolicyType");
        if (InsuranceId == Guid.Empty) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - Insurance");
        if (ClientId == Guid.Empty) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - Client");
        if (Amount <= 0) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - Amount");
    }
    public void ValidateInsuranceRelationship(Guid clientInsuranceId)
    {
        if (clientInsuranceId != InsuranceId)
            throw new Exception("La aseguradora de la póliza no coincide con la del cliente.");
    }

    public void Activate(Guid userId)
    {
        if (Status != PolicyStatusType.Inactive)
            throw new Exception("Solo se pueden activar pólizas inactivas.");

        Status = PolicyStatusType.Active;
        ActiveBy = userId;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Suspend(Guid userId, bool authorized)
    {
        if (!authorized)
            throw new Exception("Suspender una póliza requiere autorización.");
        if (Status != PolicyStatusType.Active)
            throw new Exception("Solo se pueden suspender pólizas activas.");

        Status = PolicyStatusType.Suspended;
        SuspendBy = userId;
        UpdatedAt = DateTime.UtcNow;
    }
    public void Cancel(Guid userId, bool authorized)
    {
        if (!authorized)
            throw new Exception("Cancelar una póliza requiere autorización.");
        if (Status == PolicyStatusType.Canceled)
            throw new Exception("La póliza ya está cancelada.");

        Status = PolicyStatusType.Canceled;
        CancelBy = userId;
        UpdatedAt = DateTime.UtcNow;
    }
    public void Inactivate(Guid userId, bool authorized)
    {
        bool hasMovements = _policyPayments.Count != 0;
        if (hasMovements && !authorized)
            throw new Exception("No se puede inactivar una póliza con movimientos sin autorización.");

        if (Status == PolicyStatusType.Canceled)
            throw new Exception("No se puede inactivar una póliza cancelada.");

        Status = PolicyStatusType.Inactive;
        InactiveBy = userId;
        UpdatedAt = DateTime.UtcNow;
    }
    public void AddPayment(Guid id, DateTime date, decimal amount, string? note, Guid createdBy)
    {
        var payment = PolicyPaymentEntity.Create(id, Id, DateTime.UtcNow, date, amount, note, createdBy);
        _policyPayments.Add(payment);
        UpdatedAt = DateTime.UtcNow;
    }
   
}
