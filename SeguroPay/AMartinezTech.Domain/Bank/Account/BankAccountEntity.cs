
using AMartinezTech.Core.Interfaces;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Bank.Account;

public class BankAccountEntity : IAggregateRoot
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ValueBankAccountName Name { get; private set; }
    public ValueBankAccountNumber Number { get; private set; }
    public ValueEnum<BankAccountType> Type { get; private set; }
    public string? ContactName { get; private set; }
    public string? ContactPhone { get; private set; }
    public bool IsActived { get; private set; }

    private BankAccountEntity(Guid id, DateTime createdAt, ValueBankAccountName name, ValueBankAccountNumber number, ValueEnum<BankAccountType> type, string? contactName, string? contactPhone, bool isActived)
    {
        Id = id;
        CreatedAt = createdAt;
        Name = name;
        Number = number;
        Type = type;
        ContactName = contactName;
        ContactPhone = contactPhone;
        IsActived = isActived;
    }

    public static BankAccountEntity Create(Guid id, DateTime createdAt, string name, string number, string type, string? contactName, string? contactPhone, bool isActived)
    {
        id = CreateGuid.EnsureId(id);
        return new BankAccountEntity(id, createdAt, ValueBankAccountName.Create(name), ValueBankAccountNumber.Create(number), ValueEnum<BankAccountType>.Create(type), contactName, contactPhone, isActived);
    }
    public void Activate() => IsActived = true;
    public void Deactivate() => IsActived = false;
}
