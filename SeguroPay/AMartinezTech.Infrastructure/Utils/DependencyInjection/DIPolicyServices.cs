using AMartinezTech.Application.Policy.Interfaces;
using AMartinezTech.Application.Reports.Policies.Interfaces;
using AMartinezTech.Infrastructure.Policy;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.Utils.DependencyInjection;

public static class DIPolicyServices
{
    public static IServiceCollection Add(this IServiceCollection services, string connectionString)
    {

         
        services.AddScoped<IPolicyReadRepository>(_=> new PolicyReadRepository(connectionString));
        services.AddScoped<IPolicyWriteRepository>(_=> new PolicyWriteRepository(connectionString));

        services.AddScoped<IPolicyRepositoryReport>(_=> new PolicyReportRepository(connectionString));

        return services;
    }
}
