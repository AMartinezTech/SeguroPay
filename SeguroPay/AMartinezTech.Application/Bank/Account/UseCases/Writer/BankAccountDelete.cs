using AMartinezTech.Application.Bank.Account.Interfaces;

namespace AMartinezTech.Application.Bank.Account.UseCases.Writer;

public class BankAccountDelete(IBankAccountWriterRepository repository)
{
    private readonly IBankAccountWriterRepository _repository = repository;
    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
