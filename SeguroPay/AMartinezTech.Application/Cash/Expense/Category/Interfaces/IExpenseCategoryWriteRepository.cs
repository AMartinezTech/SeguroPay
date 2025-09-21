using AMartinezTech.Domain.Cash.Expense;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Cash.Expense.Category.Interfaces;

public interface IExpenseCategoryWriteRepository : ICreate<ExpenseCategoryEntity>, IUpdate<ExpenseCategoryEntity>, IDelete<Guid>;
