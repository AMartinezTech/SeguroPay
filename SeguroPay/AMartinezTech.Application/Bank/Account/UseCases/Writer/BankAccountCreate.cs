using AMartinezTech.Application.Bank.Account.Interfaces;
using AMartinezTech.Domain.Bank.Account;

namespace AMartinezTech.Application.Bank.Account.UseCases.Writer;

public class BankAccountCreate(IBankAccountWriterRepository repository)
{
    private readonly IBankAccountWriterRepository _repository = repository;

    public async Task<Guid> CreateAsync(BankAccountDto dto)
    {

        var entity = BankAccountEntity.Create(
            Guid.Empty,
            dto.CreatedAt,
            dto.Name,
            dto.Number,
            dto.Type,
            dto.ContactName,
            dto.ContactPhone,
            dto.IsActived);

        await _repository.CreateAsync(entity);
        return entity.Id;

    }

}
