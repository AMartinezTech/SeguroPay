using AMartinezTech.Application.Policy; 
using AMartinezTech.Application.Reports.Policies;
using AMartinezTech.Application.Reports.Policies.Interfaces;
using AMartinezTech.WinForms.Policy; 
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependecyInjection;

public static class DIPolicyServices
{
    public static void Add(IServiceCollection services)
    { 
       
        services.AddTransient<IPolicyReportService, PolicyReportService>();
      
        services.AddTransient<FrmPolicyDashboardView>();
        services.AddTransient<FrmPolicyView>();
        services.AddTransient<PolicyAppService>();
    }
}
