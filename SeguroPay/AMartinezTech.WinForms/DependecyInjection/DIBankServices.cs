using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependecyInjection;

public static class DIBankServices
{
public static void Add(IServiceCollection services)
    {
        services.AddTransient<FrmBankDashboardView>();
    }    
}
