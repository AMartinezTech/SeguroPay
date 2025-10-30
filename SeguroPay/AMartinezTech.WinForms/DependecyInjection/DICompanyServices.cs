using AMartinezTech.Application.Reports.Companies;
using AMartinezTech.Application.Setting.Company;
using AMartinezTech.WinForms.Settings.Company;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependecyInjection;

public class DICompanyServices
{
    public static void AddServices(IServiceCollection services)
    {

        services.AddTransient<CompanyAppServices>();
        services.AddTransient<CompanyReportService>();
        services.AddTransient<FrmCompanyView>();
         
    }
}
