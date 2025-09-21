using AMartinezTech.Application.Bank.Account.Interfaces;
using AMartinezTech.Domain.Bank.Account;

namespace AMartinezTech.Application.Bank.Account.UseCases.Writer;

public class BankAccountUpdate(IBankAccountWriterRepository repository)
{
    private readonly IBankAccountWriterRepository _repository = repository;

    public async Task UpdateAsync(BankAccountDto dto)
    {

        var entity = BankAccountEntity.Create(
            dto.Id,
            dto.CreatedAt,
            dto.Name,
            dto.Number,
            dto.Type,
            dto.ContactName,
            dto.ContactPhone,
            dto.IsActived);

        await _repository.UpdateAsync(entity);
         
    }
}
