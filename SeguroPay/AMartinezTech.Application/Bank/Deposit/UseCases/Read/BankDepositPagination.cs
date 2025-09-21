using AMartinezTech.Application.Bank.Deposit.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Bank.Deposit.UseCases.Read;

public class BankDepositPagination(IBankDepositReadRepository repository)
{
    private readonly IBankDepositReadRepository _repository = repository;

    public async Task<PageResult<BankDepositDto>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = BankDepositMapper.ToDtoList(result.Data);
        return new PageResult<BankDepositDto>(result.TotalRecords, pageSize, dtoList);
    }
}
