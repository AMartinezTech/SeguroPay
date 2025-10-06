namespace AMartinezTech.WinForms.DependecyInjection;

using AMartinezTech.WinForms.Settings;
using AMartinezTech.WinForms.Utils.Factories;
using Microsoft.Extensions.DependencyInjection;
public class DIPresentationServices
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddTransient<IFormFactory, FormFactory>();
        services.AddTransient<FrmMainView>();
        services.AddTransient<FrmSettingDashboardView>();

        DIUserServices.AddServices(services);
        DIClientService.AddServices(services);
        DILocationService.AddService(services);
    }
}
