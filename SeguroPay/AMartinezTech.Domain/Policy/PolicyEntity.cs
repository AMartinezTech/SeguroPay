using AMartinezTech.Domain.Cash.Income;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.Exception;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Domain.Policy;
public class PolicyEntity : IAggregateRoot
{

    public Guid Id { get; private set; }
    public string PolicyNo { get; private set; }
    public PolicyTypes PolicyType { get; private set; }
    public Guid InsuranceId { get; private set; }
    public string? InsuranceName { get; private set; }
    public Guid ClientId { get; private set; }
    public string? ClientName { get; private set; }
    public PolicyPaymentFrequencies PaymentFrequency { get; private set; } = PolicyPaymentFrequencies.Monthly; // Monthly, Quarterly, Semiannual, Annual
 
    public ValuePolicyPayDay PaymentDay { get; private set; }
    public int PaymentInstallment { get; private set; }
    public decimal Amount { get; private set; }
    public string? Note { get; private set; }
    public PolicyStatus Status { get; private set; } = PolicyStatus.Inactive; // Active, Suspended, Canceled, Inactive
    public DateTime CreatedAt { get; private set; }
    public DateTime? LastPayment { get; private set; }
    private readonly List<IncomeEntity> _payments = [];
    public IReadOnlyCollection<IncomeEntity> Payments => _payments.AsReadOnly();
    private PolicyEntity(Guid id, string policyNo, PolicyTypes policyType, Guid insuranceId, Guid clientId, PolicyPaymentFrequencies paymentFrequency,  ValuePolicyPayDay paymentDay, int paymentInstallment, decimal amount, string? note, DateTime? createdAt)
    {
        Id = id;
        PolicyNo = policyNo;
        PolicyType = policyType;
        InsuranceId = insuranceId;
        ClientId = clientId;
        PaymentFrequency = paymentFrequency; 
        PaymentDay = paymentDay;
        PaymentInstallment = paymentInstallment;
        Amount = amount;
        Note = note;

        CreatedAt = createdAt ?? DateTime.UtcNow;
        Validate();
    }
    public static PolicyEntity Create(Guid id, string policyNo, string policyType, Guid insuranceId, Guid clientId, string paymentFrequency,   int paymentDay, int paymentInstallment, decimal amount, string? note, DateTime? createdAt = null)
    {
        var (_policyType, _paymentFrequency ) =
        PolicyEnumValidator.ValidateEnums(policyType, paymentFrequency);

        return new PolicyEntity(CreateGuid.EnsureId(id), policyNo, _policyType, insuranceId, clientId, _paymentFrequency, ValuePolicyPayDay.Create(paymentDay), paymentInstallment, amount, note, createdAt);
    }
    public void UpdatePolicy(string policyNo, string policyType, Guid insuranceId, string paymentFrequency, int paymentDay, decimal amount, string? note,  Guid clientId, int paymentInstallments)
    {
        if (_payments.Count != 0)
            throw new Exception($"{ErrorMessages.Get(ErrorType.HasMomevements)}");

        if (Status != PolicyStatus.Active && Status != PolicyStatus.Inactive)
            throw new Exception("Solo se puede modificar una póliza activa o inactiva.");

        var (_policyType, _paymentFrequency) =
        PolicyEnumValidator.ValidateEnums(policyType, paymentFrequency);

        PolicyNo = policyNo;
        PolicyType = _policyType;
        InsuranceId = insuranceId;
        PaymentFrequency = _paymentFrequency;
        PaymentDay = ValuePolicyPayDay.Create(paymentDay);
        Amount = amount;
        Note = note; 
        ClientId = clientId;
        PaymentInstallment = paymentInstallments;
        Validate();
    }
    public void SetStatus(string status)
    {
        if (!Enum.TryParse(status, out PolicyStatus _status)) throw new Exception($"{ErrorMessages.Get(ErrorType.InvalidType)} - Status");
        Status = _status;
    }
    public void SetAnotherProperties(string insuranceName, string clientName, DateTime? lastPayment)
    {
        InsuranceName = insuranceName;
        ClientName = clientName;
        LastPayment = lastPayment;
    }
    private void Validate()
    {

        if (string.IsNullOrWhiteSpace(PolicyNo)) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - PolicyNo");
        if (InsuranceId == Guid.Empty) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - Insurance");
        if (ClientId == Guid.Empty) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - Client");
        if (Amount <= 0) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - Amount");
        if (PaymentInstallment < 0) throw new Exception($"{ErrorMessages.Get(ErrorType.NoNegativeNum)} - PaymentInstallments");

        if (PolicyType != PolicyTypes.GeneralPolicy && PaymentInstallment > 0)
        {
            PaymentInstallment = 0;
        }
        if (PolicyType == PolicyTypes.GeneralPolicy && PaymentInstallment == 0) throw new Exception($"{ErrorMessages.Get(ErrorType.PostiveNum)} - PaymentInstallments");
    }
    public void ValidateInsuranceRelationship(Guid clientInsuranceId)
    {
        if (clientInsuranceId != InsuranceId)
            throw new Exception("La aseguradora de la póliza no coincide con la del cliente.");
    }
    public void Activate()
    {
        if (Status != PolicyStatus.Inactive)
            throw new Exception("Solo se pueden activar pólizas inactivas.");

        Status = PolicyStatus.Active;
    }
    public void Suspend(bool authorized)
    {
        if (!authorized)
            throw new Exception("Suspender una póliza requiere autorización.");
        if (Status != PolicyStatus.Active)
            throw new Exception("Solo se pueden suspender pólizas activas.");

        Status = PolicyStatus.Suspended;
    }
    public void Cancel(bool authorized)
    {
        if (!authorized)
            throw new Exception("Cancelar una póliza requiere autorización.");
        if (Status == PolicyStatus.Canceled)
            throw new Exception("La póliza ya está cancelada.");

        Status = PolicyStatus.Canceled;
    }
    public void AddPayment(Guid id, DateTime paymentDate, DateTime createdAt, Guid policyId, Guid clientId, string incomeType, string paymentMethod, string madeIn, Guid createdBy, decimal amount, string note)
    {

        _payments.Add(IncomeEntity.Create(id, paymentDate, createdAt, policyId, clientId, incomeType, paymentMethod, madeIn, createdBy, amount, note));
    }
}
