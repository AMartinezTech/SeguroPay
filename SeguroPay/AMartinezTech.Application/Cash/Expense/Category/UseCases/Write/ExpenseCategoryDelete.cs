using AMartinezTech.Application.Cash.Expense.Category.Interfaces;

namespace AMartinezTech.Application.Cash.Expense.Category.UseCases.Write;

public class ExpenseCategoryDelete(IExpenseCategoryWriteRepository repository)
{
    private readonly IExpenseCategoryWriteRepository _repository = repository;

    public async Task ExecuteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
