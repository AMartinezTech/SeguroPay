using AMartinezTech.Domain.Bank;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Bank;

public interface IBankAccountWriteRepository : ICreate<BankAccountEntity>, IUpdate<BankAccountEntity>, IDelete<Guid>
{
    // Movements
    Task AddMovementAsync(BankAccountMovement movement);
    Task RemoveMovementAsync(Guid movementId);
}
