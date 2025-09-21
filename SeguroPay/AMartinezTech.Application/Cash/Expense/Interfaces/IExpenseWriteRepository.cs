using AMartinezTech.Domain.Cash.Expense;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Cash.Expense.Interfaces;

public interface IExpenseWriteRepository : ICreate<ExpenseEntity>, IUpdate<ExpenseEntity>, IDelete<Guid>;
