using AMartinezTech.WinForms.Insurance;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependecyInjection;

public static  class DIInsuranceServices
{
    public static void Add(IServiceCollection services)
    {
        services.AddTransient<FrmInsuranceDashboardView>();
    }
}
