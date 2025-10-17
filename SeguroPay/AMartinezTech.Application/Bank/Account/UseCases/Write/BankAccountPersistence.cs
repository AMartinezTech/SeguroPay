using AMartinezTech.Application.Bank.Account.Interfaces;
using AMartinezTech.Domain.Bank.Account;

namespace AMartinezTech.Application.Bank.Account.UseCases.Write;

public class BankAccountPersistence(IBankAccountWriterRepository repository)
{
    private readonly IBankAccountWriterRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(BankAccountDto dto)
    {
        var entity = BankAccountEntity.Create(
           dto.Id,
           dto.CreatedAt,
           dto.Name,
           dto.Number,
           dto.Type,
           dto.ContactName,
           dto.ContactPhone,
           dto.IsActive);

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }

        return entity.Id;
    }
}
