using AMartinezTech.Application.Cash.Expense.Interfaces;
using AMartinezTech.Domain.Cash.Expense;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Infrastructure.Utils.Persistence;

namespace AMartinezTech.Infrastructure.Cash.Expense;

public class ExpenseReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IExpenseReadRepository
{
    public Task<ByDateResult<ExpenseEntity>> GetByDateAsync(DateTime initialDate, DateTime endDate, bool? IsActive)
    {
        throw new NotImplementedException();
    }

    public Task<PageResult<ExpenseEntity>> PaginationAsync(int pageNumber, int pageSize, bool? IsActive)
    {
        throw new NotImplementedException();
    }
}
