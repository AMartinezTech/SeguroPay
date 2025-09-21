
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Core.Interfaces;
using AMartinezTech.Domain.Utils.ValueObjects;
using AMartinezTech.Domain.Utils;


namespace AMartinezTech.Domain.Bank.Deposit;

public class BankDepositEntity : IAggregateRoot
{
    public Guid Id { get; private set; }
    public ValueEnum<BankDepositType> Type { get; private set; }
    public ValueGuid BankAccountId { get; private set; }
    public ValuePositiveNum Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string? Reference { get; private set; }
    public string? Note { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Guid CreatedBy { get; private set; }

    private BankDepositEntity(Guid id, ValueEnum<BankDepositType> type, ValueGuid bankAccountId, ValuePositiveNum amount, DateTime date, string? reference, string? note, DateTime createdAt, Guid createdBy)
    {
        Id = id;
        Type = type;
        BankAccountId = bankAccountId;
        Amount = amount;
        Date = date;
        Reference = reference;
        Note = note;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }

    public static BankDepositEntity Create(Guid id, string type, Guid bankAccountId, decimal amount, DateTime date, string? reference, string? note, DateTime createdAt, Guid createdBy)
    {
        id = CreateGuid.EnsureId(id);
        return new BankDepositEntity(id, ValueEnum<BankDepositType>.Create(type), ValueGuid.Create(bankAccountId,"banco"), ValuePositiveNum.Create(amount,"Monto"), date, reference, note, createdAt, createdBy);
    }
}
