using AMartinezTech.Application.Bank;
using AMartinezTech.Infrastructure.Bank;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.Utils.DependencyInjection;

internal static class DIBankServices
{
    internal static IServiceCollection Add(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IBankAccountReadRepository>(sp => new BankAccountReadRepository(connectionString));
        services.AddScoped<IBankAccountWriteRepository>(sp => new BankAccountWriteRepository(connectionString));

        return services;

    }
}
