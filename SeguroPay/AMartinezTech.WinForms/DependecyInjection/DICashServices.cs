using AMartinezTech.Application.Cash.Expense;
using AMartinezTech.Application.Cash.Expense.Category;
using AMartinezTech.Application.Cash.Income;
using AMartinezTech.Application.Reports.Incomes;
using AMartinezTech.WinForms.Cash;
using AMartinezTech.WinForms.Cash.Expense;
using AMartinezTech.WinForms.Cash.Expense.Category;
using AMartinezTech.WinForms.Cash.Income;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependecyInjection;

public static class DICashServices
{
    public static void Add(IServiceCollection services)
    {
        services.AddTransient<FrmCashDashboardView>();
        
        // Income
        services.AddTransient<IncomeAppServices>();
        services.AddTransient<OtherIncomeAppService>();
        services.AddTransient<IncomeReportService>();
        services.AddTransient<FrmIncomeView>();
        services.AddTransient<FrmOtherIncomeView>();

        // Expense
        services.AddTransient<ExpenseAppService>();
        services.AddTransient<ExpenseCategoryAppService>();
        services.AddTransient<FrmExpenseCategory>();
        services.AddTransient<FrmExpenseView>();
    }
}
