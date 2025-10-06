using AMartinezTech.Application.Location.City.Interfaces;
using AMartinezTech.Infrastructure.Location;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.Utils.DependencyInjection;

public static class DILocationService
{
    public static IServiceCollection AddLocationModule(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<ICityReadRepository>(sp => new CityReadRepository(connectionString));
        
        return services;
    }
}
