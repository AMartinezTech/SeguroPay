using AMartinezTech.Application.Setting.User;
using AMartinezTech.Application.Setting.User.Interfaces;
using AMartinezTech.WinForms.Auth;
using AMartinezTech.WinForms.Settings.User;

using Microsoft.Extensions.DependencyInjection; 

namespace AMartinezTech.WinForms.DependecyInjection;

public class DIUserServices
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddSingleton<ICurrectUser, CurrentUser>();
        services.AddTransient<UserApplicationService>(); 
        services.AddTransient<FrmUserView>();
        services.AddTransient<FrmLoginView>();
        services.AddTransient<UserLoginController>();

        services.AddTransient<UserController>();
    }
}
