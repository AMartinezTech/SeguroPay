using AMartinezTech.Application.Bank;
using AMartinezTech.WinForms.Bank;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependecyInjection;

public static class DIBankServices
{
    public static void Add(IServiceCollection services)
    {
        services.AddTransient<FrmBankDashboardView>();
        services.AddTransient<FrmBankAccount>();
        services.AddTransient<BankAccountAppService>();
    }
}
