using AMartinezTech.Application.Policy;
using AMartinezTech.Application.Policy.Type;
using AMartinezTech.WinForms.Policy;
using AMartinezTech.WinForms.Policy.Type;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependecyInjection;

public static class DIPolicyServices
{
    public static void Add(IServiceCollection services)
    {

        services.AddTransient<FrmPolicyTypeView>();
        services.AddTransient<PolicyTypeApplicationServices>();

        services.AddTransient<FrmPolicyDashboardView>();
        services.AddTransient<FrmPolicyView>();
        services.AddTransient<PolicyApplicationService>();
    }
}
