using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        DIClient.AddClientModule(services, connectionString);

        return services;
    }
}
