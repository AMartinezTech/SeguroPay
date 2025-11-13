using AMartinezTech.Application.Cash.Expense.Category;
using AMartinezTech.Application.Cash.Expense.Interfaces;
using AMartinezTech.Infrastructure.Cash.Expense;
using AMartinezTech.Infrastructure.Cash.Expense.Category;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.Utils.DependencyInjection;

internal static class DIExpenseServices
{
    internal static IServiceCollection Add(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IExpenseCategoryReadRepository>(_=> new ExpenseCategoryReadRepository(connectionString));
        services.AddScoped<IExpenseCategoryWriteRepository>(_=> new ExpenseCategoryWriteRepository(connectionString));
        
        services.AddScoped<IExpenseReadRepository>(_=> new ExpenseReadRepository(connectionString));
        services.AddScoped<IExpenseWriteRepository>(_=> new ExpenseWriteRepository(connectionString));


        return services;
    }
}
