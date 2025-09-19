using AMartinezTech.Application.Setting.DocIdentity; 
using AMartinezTech.Infrastructure.Setting.DocIdentity;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.Utils.DependencyInjection;

public static class DISetting
{
    public static IServiceCollection AddSettingModule(this IServiceCollection services,  string connectionString)
    {
        services.AddScoped<IDocIdentityReadRepository>(sp => new DocIdentityReadRepository(connectionString));

        return services;
    }
}
