using AMartinezTech.WinForms.Policy;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependecyInjection;

public static class DIPolicyServices
{
    public static void Add(IServiceCollection services)
    {
        services.AddTransient<FrmPolicyDashboardView>();
    }
}
