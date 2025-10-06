using AMartinezTech.Application.Location.City.UseCases.Read;
using AMartinezTech.Application.Location.Street;
using AMartinezTech.WinForms.Location.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependecyInjection;

public class DILocationService
{
    public static void AddService(IServiceCollection services)
    {
        // City
        services.AddTransient<CityPagination>();

        // Street
        services.AddTransient<StreetApplicationService>();
        services.AddTransient<FrmStreetView>();
    }
}
