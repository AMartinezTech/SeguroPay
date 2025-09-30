namespace AMartinezTech.WinForms.DependecyInjection;

using AMartinezTech.WinForms.Utils.Factories;
using Microsoft.Extensions.DependencyInjection;
public class DIPresentationServices
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddTransient<IFormFactory, FormFactory>();
        services.AddTransient<FrmMainView>();

        DIUserServices.AddServices(services);
    }
}
