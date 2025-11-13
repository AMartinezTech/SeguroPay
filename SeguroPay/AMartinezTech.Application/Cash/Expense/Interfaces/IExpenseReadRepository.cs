using AMartinezTech.Domain.Cash.Expense;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Cash.Expense.Interfaces;

public interface IExpenseReadRepository :  IPagination<ExpenseEntity>, IFilter<ExpenseEntity>, IGetById<ExpenseEntity,Guid>;
