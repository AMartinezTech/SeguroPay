using AMartinezTech.Application.Cash.Expense.Category.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Cash.Expense.Category.UseCases.Read;

public class ExpenseCategoryPagination(IExpenseCategoryReadRepository repository)
{
    private readonly IExpenseCategoryReadRepository _repository = repository;

    public async Task<PageResult<ExpenseCategoryDto>> ExecuteAsync(int pageNumber, int pageSize, bool? IsActive)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, IsActive);
        var dtoList = ExpenseCategoryMapper.ToDtoList(result.Data);
        return new PageResult<ExpenseCategoryDto>(result.TotalRecords, pageSize, dtoList); 
    } 
}
