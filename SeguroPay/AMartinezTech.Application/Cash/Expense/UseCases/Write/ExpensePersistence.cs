using AMartinezTech.Application.Cash.Expense.Interfaces;
using AMartinezTech.Domain.Cash.Expense;

namespace AMartinezTech.Application.Cash.Expense.UseCases.Write;

public class ExpensePersistence(IExpenseWriteRepository repository)
{
    private readonly IExpenseWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(ExpenseDto dto)
    {
        var entity = ExpenseEntity.Create(
            dto.Id,
            dto.CreatedAt,
            dto.CategoryId,
            dto.Amount,
            dto.Note,
            dto.IsActive);

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }

        return entity.Id;
    }
}
