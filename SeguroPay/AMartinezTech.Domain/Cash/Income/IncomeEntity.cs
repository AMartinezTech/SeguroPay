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
    public Guid DocIdRelated { get; private set; }
    public IncomeTypes IncomeType { get; private set; }
    public PaymentMethods PaymentMethod { get; private set; }
    public IncomeMadeIn MadeIn { get; private set; }
    public Guid CreatedBy { get; private set; }
    public decimal Amount { get; private set; }

    private IncomeEntity(Guid id, DateTime paymentDate, DateTime createdAt, Guid docIdRelated, IncomeTypes incomeType, PaymentMethods paymentMethod, IncomeMadeIn madeIn, Guid createdBy, decimal amount)
    {
        Id = id;
        PaymentDate = paymentDate;
        CreatedAt = createdAt;
        DocIdRelated = docIdRelated;
        IncomeType = incomeType;
        PaymentMethod = paymentMethod;
        MadeIn = madeIn;
        CreatedBy = createdBy;
        Amount = amount;
    }

    public static IncomeEntity Create(Guid id, DateTime paymentDate, DateTime createdAt, Guid docIdRelated, string incomeType, string paymentMethod, string madeIn, Guid createdBy, decimal amount)
    {

        if (docIdRelated == Guid.Empty) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} -  DocIdRelated");


        var (_incomeType, _paymentMethod, _madeIn) = IncomeEnumValidator.ValidateEnums(incomeType, madeIn, paymentMethod);

        if (createdBy == Guid.Empty) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} -  CreatedBy");

        if (amount <= 0) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} -  Amount");

        return new IncomeEntity(CreateGuid.EnsureId(id), paymentDate, createdAt, docIdRelated, _incomeType, _paymentMethod, _madeIn, createdBy, amount);
    }
}
