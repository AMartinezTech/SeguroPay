using AMartinezTech.WinForms.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependecyInjection;

public class DIUserServices
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddTransient<FrmLoginView>();
        services.AddTransient<UserLoginController>();
    }
}
