using AMartinezTech.Domain.Cash.Expense;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Cash.Expense.Category;

public interface IExpenseCategoryReadRepository : IPagination<ExpenseCategoryEntity>, IGetById<ExpenseCategoryEntity, Guid>;
