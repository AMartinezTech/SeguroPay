using AMartinezTech.Application.Setting.User.UseCases.Read;
using AMartinezTech.Application.Setting.User.UseCases.Write;
using AMartinezTech.WinForms.Auth;
using AMartinezTech.WinForms.Settings.User;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependecyInjection;

public class DIUserServices
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddTransient<FrmUserView>();
        services.AddTransient<FrmLoginView>();
        services.AddTransient<UserLoginController>();

        services.AddTransient<UserController>();
        services.AddTransient<UserPersistence>();
        services.AddTransient<UserGetById>();
        services.AddTransient<UserFilter>();
    }
}
