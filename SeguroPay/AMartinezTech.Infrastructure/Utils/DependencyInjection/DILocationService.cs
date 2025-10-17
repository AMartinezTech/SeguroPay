using AMartinezTech.Application.Location.City.Interfaces;
using AMartinezTech.Application.Location.Street.Interfaces;
using AMartinezTech.Infrastructure.Location;
using AMartinezTech.Infrastructure.Location.Street;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.Utils.DependencyInjection;

public static class DILocationService
{
    public static IServiceCollection Add(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<ICityReadRepository>(sp => new CityReadRepository(connectionString));
        services.AddScoped<IStreetReadRepository>(sp => new StreetReadRepository(connectionString));
        services.AddScoped<IStreetWriteRepository>(sp => new StreetWriteRepository(connectionString));
        
        return services;
    }
}
