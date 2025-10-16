using AMartinezTech.Application.Location.City.UseCases.Read;
using AMartinezTech.Application.Location.Street;
using AMartinezTech.WinForms.Location.Controllers;
using AMartinezTech.WinForms.Location.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependecyInjection;

public class DILocationServices
{
    public static void Add(IServiceCollection services)
    {
        // City
        services.AddTransient<CityPagination>();

        // Street
        services.AddTransient<StreetApplicationService>();
        services.AddTransient<FrmStreetView>();
        services.AddTransient<StreetController>();
    }
}
