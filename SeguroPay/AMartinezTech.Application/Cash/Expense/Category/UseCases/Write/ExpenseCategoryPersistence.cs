using AMartinezTech.Application.Cash.Expense.Category.Interfaces;
using AMartinezTech.Domain.Cash.Expense;

namespace AMartinezTech.Application.Cash.Expense.Category.UseCases.Write;

public class ExpenseCategoryPersistence(IExpenseCategoryWriteRepository repository)
{
    private readonly IExpenseCategoryWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(ExpenseCategoryDto dto)
    {
        var entity = ExpenseCategoryEntity.Create(
            dto.Id,
            dto.Name,
            dto.IsActive
            );

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }

        return entity.Id;
    }
}
