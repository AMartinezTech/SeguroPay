using AMartinezTech.Application.Insurance.Interfaces;
using AMartinezTech.Infrastructure.Insurances;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.Utils.DependencyInjection;

public static class DIInsuranceServices
{
    public static IServiceCollection Add(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IInsuranceReadRepository>(_ => new InsuranceReadRepository(connectionString));
        services.AddScoped<IInsuranceWriteRepository>(_ => new InsuranceWriteRepository(connectionString));

        return services;
    }
}
