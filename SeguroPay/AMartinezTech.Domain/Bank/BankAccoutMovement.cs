using AMartinezTech.Domain.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Bank;

public class BankAccountMovement
{
    public Guid Id { get; private set; }
    public Guid BankAccountId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public BankAccountMovementTypes MovementTypes { get; private set; }
    public decimal Amount { get; private set; }
    public string? Description { get; private set; }
    public Guid CreatedBy { get; private set; }
    public string? CreatedByName { get; set; } = string.Empty;

    // Constructor privado → SOLO el aggregate puede crearlo
    private BankAccountMovement(Guid id, Guid bankAccountId, DateTime createdAt,
        BankAccountMovementTypes movementType, decimal amount, string? description, Guid createdBy, string? createdByName)
    {
        Id = id;
        BankAccountId = bankAccountId;
        CreatedAt = createdAt;
        MovementTypes = movementType;
        Amount = amount;
        Description = description;
        CreatedBy = createdBy;
        CreatedByName = createdByName;
    }

    // Factory interno → visible solo dentro del assembly de dominio
    internal static BankAccountMovement Create(Guid bankAccountId,DateTime createdAt,string type, decimal amount, string? description, Guid createdBy, string? createdByName)
    {

        if (!Enum.TryParse(type, ignoreCase: true, out BankAccountMovementTypes movementType))
            throw new ValidationException($"El tipo de movimiento '{type}' no es válido.");


        return new BankAccountMovement(Guid.NewGuid(), bankAccountId, createdAt, movementType, amount, description, createdBy, createdByName);
    }

}
