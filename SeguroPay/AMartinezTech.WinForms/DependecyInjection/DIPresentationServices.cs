namespace AMartinezTech.WinForms.DependecyInjection;

using AMartinezTech.Application.Reports.Companies;
using AMartinezTech.WinForms.Cash.Income.Print;
using AMartinezTech.WinForms.Settings;
using AMartinezTech.WinForms.Utils.Factories;
using Microsoft.Extensions.DependencyInjection;
public class DIPresentationServices
{
    public static void AddServices(IServiceCollection services)
    {

        


        services.AddTransient<IFormFactory, FormFactory>();
        services.AddTransient<FrmMainView>();
        services.AddTransient<FrmSettingDashboardView>();
        services.AddTransient<FrmPrintIncomePreviewView>();

        DIBankServices.Add(services);
        DICashServices.Add(services);
        DIClientServices.Add(services);
        DIInsuranceServices.Add(services);
        DILocationServices.Add(services);
        DIPolicyServices.Add(services);
        DIUserServices.Add(services);
        DICompanyServices.AddServices(services);
    }
}
