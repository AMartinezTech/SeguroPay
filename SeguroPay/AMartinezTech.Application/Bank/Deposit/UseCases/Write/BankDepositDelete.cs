using AMartinezTech.Application.Bank.Deposit.Interfaces; 

namespace AMartinezTech.Application.Bank.Deposit.UseCases.Write;

public class BankDepositDelete(IBankDepositWriteRepository repository)
{
    private readonly IBankDepositWriteRepository _repository = repository;

    public async Task ExecuteAsync(Guid id)
    { 
        await _repository.DeleteAsync(id);
    }
}
