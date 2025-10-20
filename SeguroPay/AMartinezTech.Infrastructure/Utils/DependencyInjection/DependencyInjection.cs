using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.Utils.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {
        DIClientServices.Add(services, connectionString);
        DIClientServices.Add(services, connectionString);
        DIInsuranceServices.Add(services, connectionString);
        DISettingServices.Add(services, connectionString);
        DILocationServices.Add(services, connectionString);
        DIPolicyServices.Add(services, connectionString);
        return services;
    }
}
