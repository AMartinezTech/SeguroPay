using AMartinezTech.Application.Reports.Companies;
using AMartinezTech.Application.Setting.Company;
using AMartinezTech.Application.Setting.DocIdentity;
using AMartinezTech.Application.Setting.User.Interfaces;
using AMartinezTech.Infrastructure.Setting.Company;
using AMartinezTech.Infrastructure.Setting.DocIdentity;
using AMartinezTech.Infrastructure.Setting.User;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.Utils.DependencyInjection;

public static class DISettingServices
{
    public static IServiceCollection Add(this IServiceCollection services,  string connectionString)
    {
        //Company
        services.AddScoped<ICompanyReportRepository>(sp => new CompanyReportRepository(connectionString));
        services.AddScoped<ICompanyReadRepository>(sp => new CompanyReadRepository(connectionString));
        services.AddScoped<ICompanyWriteRepository>(sp => new CompanyWriteRepository(connectionString));

        //Identity Doc
        services.AddScoped<IDocIdentityReadRepository>(sp => new DocIdentityReadRepository(connectionString));

        //User
        services.AddScoped<IUserReadRepository>(sp => new UserReadRepository(connectionString));
        services.AddScoped<IUserWriteRepository>(sp => new UserWriteRepository(connectionString));

        return services;
    }
}
