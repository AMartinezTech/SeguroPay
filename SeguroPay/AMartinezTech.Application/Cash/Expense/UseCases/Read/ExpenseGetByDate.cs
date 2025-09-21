using AMartinezTech.Application.Cash.Expense.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Cash.Expense.UseCases.Read;

public class ExpenseGetByDate(IExpenseReadRepository repository)
{
    private readonly IExpenseReadRepository _repository = repository;

    public async Task<ByDateResult<ExpenseDto>> GetByDateAsync(DateTime initialDate, DateTime endDate, bool? isActived)
    {
        var result = await _repository.GetByDateAsync(initialDate, endDate, isActived);
        var dtoList = ExpenseMapper.ToDtoList(result.Data);
        return new ByDateResult<ExpenseDto>(initialDate, endDate, dtoList);
    }
}

