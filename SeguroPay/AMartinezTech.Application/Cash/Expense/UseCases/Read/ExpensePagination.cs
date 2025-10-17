using AMartinezTech.Application.Cash.Expense.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Cash.Expense.UseCases.Read;

public class ExpensePagination(IExpenseReadRepository repository)
{
    private readonly IExpenseReadRepository _repository = repository;

    public async Task<PageResult<ExpenseDto>> ExecuteAsync(int pageNumber, int pageSize, bool? IsActive)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, IsActive);
        var dtoList = ExpenseMapper.ToDtoList(result.Data);

        return new PageResult<ExpenseDto>(result.TotalRecords, pageSize, dtoList);
    }
}
