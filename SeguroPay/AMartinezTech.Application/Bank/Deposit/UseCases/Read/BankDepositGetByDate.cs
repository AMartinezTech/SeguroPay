using AMartinezTech.Application.Bank.Deposit.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Bank.Deposit.UseCases.Read;

public class BankDepositGetByDate(IBankDepositReadRepository repository)
{
    private readonly IBankDepositReadRepository _repository = repository;

    public async Task<ByDateResult<BankDepositDto>> ExecuteAsync(DateTime initialDate, DateTime endDate, bool? isActived)
    {
        var result = await _repository.GetByDateAsync(initialDate, endDate, isActived);
        var dtoList = BankDepositMapper.ToDtoList(result.Data);
        return new ByDateResult<BankDepositDto>(initialDate, endDate, dtoList);
    }
}
