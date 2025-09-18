using AMartinezTech.Application.Clients.Repositories;
using AMartinezTech.Infrastructure.Clients.Writer;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.DependencyInjection;

public static class DIClient
{
    public static IServiceCollection AddClientModule(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IClientWriteRepository>(sp => new ClientWriterRepository(connectionString));

        return services;
    }
}
