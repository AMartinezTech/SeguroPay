using AMartinezTech.Application.Client.Interfaces;
using AMartinezTech.Infrastructure.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.Utils.DependencyInjection;

public static class DIClient
{
    public static IServiceCollection AddClientModule(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IClientWriteRepository>(sp => new ClientWriterRepository(connectionString));
        services.AddScoped<IClientReadRepository>(sp => new ClientReadRepository(connectionString));

        return services;
    }
}
