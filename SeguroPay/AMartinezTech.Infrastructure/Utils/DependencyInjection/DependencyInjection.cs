using AMartinezTech.Application.Utils.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.Utils.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {

        services.AddSingleton<IServerTimeProvider>(_ => new ServerTimeProvider(connectionString));
        DIClientServices.Add(services, connectionString);
        DIClientServices.Add(services, connectionString);
        DIInsuranceServices.Add(services, connectionString);
        DISettingServices.Add(services, connectionString);
        DILocationServices.Add(services, connectionString);
        DIPolicyServices.Add(services, connectionString);
        DIIncomeServices.Add(services, connectionString);
        return services;
    }
}
