using AMartinezTech.Domain.Cash.Expense;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Cash.Expense.Category;

public interface IExpenseCategoryWriteRepository : ICreate<ExpenseCategoryEntity>, IUpdate<ExpenseCategoryEntity>;
