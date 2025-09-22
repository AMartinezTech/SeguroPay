using AMartinezTech.Application.Cash.Expense.Interfaces;

namespace AMartinezTech.Application.Cash.Expense.UseCases.Write;

public class ExpenseDelete(IExpenseWriteRepository repository)
{
    private readonly IExpenseWriteRepository _repository = repository;

    public async Task ExecuteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}

