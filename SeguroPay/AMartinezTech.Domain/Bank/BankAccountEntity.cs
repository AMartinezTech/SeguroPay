using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.Exception;
using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Bank;

public class BankAccountEntity : IAggregateRoot
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ValueBankAccountName Name { get; private set; }
    public ValueBankAccountNumber Number { get; private set; }
    public ValueEnum<BankAccountTypes> Type { get; private set; }
    public string? ContactName { get; private set; }
    public string? ContactPhone { get; private set; }
    public bool IsActive { get; private set; }
    public bool HasMovements { get; private set; }

    private readonly List<BankAccountMovement> _movements = [];
    public IReadOnlyCollection<BankAccountMovement> Movements => _movements.AsReadOnly();

    
    private BankAccountEntity(Guid id, DateTime createdAt, ValueBankAccountName name, ValueBankAccountNumber number, ValueEnum<BankAccountTypes> type, string? contactName, string? contactPhone, bool isActive)
    {
        Id = id;
        CreatedAt = createdAt;
        Name = name;
        Number = number;
        Type = type;
        ContactName = contactName;
        ContactPhone = contactPhone;
        IsActive = isActive;
    }

    public static BankAccountEntity Create(Guid id, DateTime createdAt, string name, string number, string type, string? contactName, string? contactPhone, bool isActive)
    {
        id = CreateGuid.EnsureId(id);
        return new BankAccountEntity(id, createdAt, ValueBankAccountName.Create(name), ValueBankAccountNumber.Create(number), ValueEnum<BankAccountTypes>.Create(type), contactName, contactPhone, isActive);
    }

    public void Update(string name, string number, string type, string? contactName, string? contactPhone, bool isActive)
    {
        if (HasMovements)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.HasMomevements)} - BankAccountEntity! ");

        Name = ValueBankAccountName.Create(name);
        Number = ValueBankAccountNumber.Create(number);
        Type = ValueEnum<BankAccountTypes>.Create(type);
        ContactName = contactName;
        ContactPhone = contactPhone;
        IsActive = isActive;

    }

    public BankAccountMovement AddMovement(DateTime createdAt, string type, decimal amount, string? description, Guid createdBy, string? createdByName)
    {
        if (!IsActive)
            throw new ValidationException("No se puede registrar un movimiento en una cuenta inactiva.");

        if (amount <= 0)
            throw new ValidationException("El monto debe ser mayor que cero.");


        var movement = BankAccountMovement.Create(Id, createdAt, type, amount, description, createdBy, createdByName);

        _movements.Add(movement);
        HasMovements = true;

        return movement;
    }
    public void RemoveMovement(Guid movementId)
    {
        var movement = _movements.FirstOrDefault(m => m.Id == movementId) ?? throw new ValidationException("El movimiento que intenta eliminar no existe.");
        _movements.Remove(movement);

        // Si ya no quedan movimientos
        if (_movements.Count == 0)
            HasMovements = false;
    }
    public void EnsureNoMovementsBeforeDelete()
    {
        if (HasMovements)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.HasMomevements)} - BankAccountEntity! ");
    }


}
