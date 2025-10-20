using AMartinezTech.Application.Policy.Interfaces;
using AMartinezTech.Application.Policy.Type;
using AMartinezTech.Infrastructure.Policy;
using AMartinezTech.Infrastructure.Policy.Type;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.Utils.DependencyInjection;

public static class DIPolicyServices
{
    public static IServiceCollection Add(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IPolicyTypeReadRepository>(_=> new PolicyTypeReadRepository(connectionString));   
        services.AddScoped<IPolicyTypeWriteRepository>(_=> new PolicyTypeWriteRepository(connectionString));


        services.AddScoped<IPolicyReadRepository>(_=> new PolicyReadRepository(connectionString));
        services.AddScoped<IPolicyWriteRepository>(_=> new PolicyWriteRepository(connectionString));

        return services;
    }
}
