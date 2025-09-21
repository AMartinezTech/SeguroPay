using AMartinezTech.Application.Client;
using AMartinezTech.Application.Client.Categories;
using AMartinezTech.Application.Client.Types;
using AMartinezTech.Infrastructure.Clients;
using AMartinezTech.Infrastructure.Clients.Categories;
using AMartinezTech.Infrastructure.Clients.Type;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.Utils.DependencyInjection;

public static class DIClient
{
    public static IServiceCollection AddClientModule(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IClientWriteRepository>(sp => new ClientWriterRepository(connectionString));
        services.AddScoped<IClientReadRepository>(sp => new ClientReadRepository(connectionString));
        services.AddScoped<IClientCategoryReadRepository>(sp => new ClientCategoryReadRepository(connectionString));
        services.AddScoped<IClientTypeReadRepository>(sp => new ClientTypeReadRepository(connectionString));
        

        return services;
    }
}
