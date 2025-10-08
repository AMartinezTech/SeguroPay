using AMartinezTech.Application.Client;
using AMartinezTech.Application.Reports.Clients;
using AMartinezTech.WinForms.Client;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependecyInjection;

public class DIClientService
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddTransient<ClientReportService>();

        services.AddTransient<FrmClientDashboardView>();
        services.AddTransient<FrmClientView>();
        services.AddTransient<ClientController>();
        services.AddTransient<ClientApplicationService>();
    }
}
