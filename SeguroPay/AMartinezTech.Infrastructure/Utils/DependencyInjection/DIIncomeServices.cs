using AMartinezTech.Application.Cash.Income;
using AMartinezTech.Infrastructure.Cash.Income;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.Utils.DependencyInjection;

public static class DIIncomeServices
{
    public static IServiceCollection Add(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IIncomeReadRepository>(_ => new IncomeReadRepository(connectionString));
        services.AddScoped<IIncomeWriteRepository>(_ => new IncomeWriteRepository(connectionString));
        return services;
    }
}
