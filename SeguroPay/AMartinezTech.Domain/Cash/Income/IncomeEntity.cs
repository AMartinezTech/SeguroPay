using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.Exception;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Domain.Cash.Income;

public class IncomeEntity : IAggregateRoot
{
    public Guid Id { get; private set; }
    public DateTime PaymentDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Guid PolicyId { get; private set; }
    public Guid ClientId { get; private set; }
    public IncomeTypes IncomeType { get; private set; }
    public PaymentMethods PaymentMethod { get; private set; }
    public IncomeMadeIn MadeIn { get; private set; }
    public Guid CreatedBy { get; private set; }
    public decimal Amount { get; private set; }
    public string? Note {  get; private set; }
    public string? ClientName { get; private set; }
    public string? TypeName {  get; private set; }

    private IncomeEntity(Guid id, DateTime paymentDate, DateTime createdAt, Guid policyId, Guid clientId, IncomeTypes incomeType, PaymentMethods paymentMethod, IncomeMadeIn madeIn, Guid createdBy, decimal amount, string? note)
    {
        Id = id;
        PaymentDate = paymentDate;
        CreatedAt = createdAt;
        PolicyId = policyId;
        ClientId = clientId;
        IncomeType = incomeType;
        PaymentMethod = paymentMethod;
        MadeIn = madeIn;
        CreatedBy = createdBy;
        Amount = amount;
        Note = note;
    }
    
    public static IncomeEntity Create(Guid id, DateTime paymentDate, DateTime createdAt, Guid policyId, Guid clientId, string incomeType, string paymentMethod, string madeIn, Guid createdBy, decimal amount, string? note)
    {

        if (policyId == Guid.Empty) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} -  PolicyId");

        if (clientId == Guid.Empty) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} -  ClientId");
         
        var (_incomeType, _paymentMethod, _madeIn) = IncomeEnumValidator.ValidateEnums(incomeType, madeIn, paymentMethod);

        if (createdBy == Guid.Empty) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} -  CreatedBy");

        if (amount <= 0) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} -  Amount");

        return new IncomeEntity(CreateGuid.EnsureId(id), paymentDate, createdAt, policyId, clientId, _incomeType, _paymentMethod, _madeIn, createdBy, amount, note);
    }

    public void Update(string paymentMethod, string madeIn, string? note)
    {
        var _paymentMethod = EnumValidator.ParseEnum<PaymentMethods>(paymentMethod, nameof(PaymentMethods));
        var _incomeMadeIn = EnumValidator.ParseEnum<IncomeMadeIn>(madeIn, nameof(IncomeMadeIn));

        PaymentMethod = _paymentMethod;
        MadeIn = _incomeMadeIn;
        Note = note;
    }
    public void SetOpcionalProperties(string? clientName, string? typeName)
    {
        ClientName = clientName;
        TypeName = typeName;
    }
}
