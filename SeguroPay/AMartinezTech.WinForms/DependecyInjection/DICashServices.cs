using AMartinezTech.WinForms.Cash;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependecyInjection;

public static class DICashServices
{
    public static void Add(IServiceCollection services)
    {
        services.AddTransient<FrmCashDashboardView>();
    }
}
