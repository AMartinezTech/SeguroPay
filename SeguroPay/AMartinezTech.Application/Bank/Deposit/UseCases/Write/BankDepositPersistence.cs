using AMartinezTech.Application.Bank.Deposit.Interfaces;
using AMartinezTech.Domain.Bank.Deposit;

namespace AMartinezTech.Application.Bank.Deposit.UseCases.Write;

public class BankDepositPersistence(IBankDepositWriteRepository repository)
{
    private readonly IBankDepositWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(BankDepositDto dto)
    {
        var entity = BankDepositEntity.Create(
            dto.Id,
            dto.Type,
            dto.BankAccountId,
            dto.Amount,
            dto.Date,
            dto.Reference,
            dto.Note,
            dto.CreatedAt,
            dto.CreatedBy);

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }
        
        return entity.Id;
    }
}
