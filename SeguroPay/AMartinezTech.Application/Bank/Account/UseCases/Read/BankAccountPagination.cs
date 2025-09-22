using AMartinezTech.Application.Bank.Account.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Bank.Account.UseCases.Read;

public class BankAccountPagination(IBankAccountReadRepository repository)
{
    private readonly IBankAccountReadRepository _repository = repository;

    public async Task<PageResult<BankAccountDto>> ExecuteAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = BankAccountMapper.ToDtoList(result.Data);

        return new PageResult<BankAccountDto>(result.TotalRecords,pageSize,dtoList);    
    }
}
