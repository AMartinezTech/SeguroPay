using AMartinezTech.Infrastructure.Utils.DependencyInjection;
using AMartinezTech.WinForms.Auth;
using AMartinezTech.WinForms.DependecyInjection;
using AMartinezTech.WinForms.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinFormsApp = System.Windows.Forms.Application;

namespace AMartinezTech.WinForms;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        var host = CreateHostBuilder().Build();

        var frmMainView = host.Services.GetRequiredService<FrmMainView>();
        var frmLogin = host.Services.GetRequiredService<FrmLoginView>();
        var result = frmLogin.ShowDialog();
        if (result == DialogResult.OK)
        {
            WinFormsApp.Run(frmMainView);
        }
    }

    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
             .ConfigureServices((context, services) =>
             {
                 // Registrar servicios de presentación
                 DIPresentationServices.AddServices(services);

                 // Cargar configuración personalizada
                 var dbConfig = DatabaseConfig.Load("AppSettings.json");
                 var connectionString = dbConfig.GetConnectionString();

                 if (string.IsNullOrEmpty(connectionString))
                     throw new InvalidOperationException("No se encontró la cadena de conexión 'DefaultConnection' en AppSettings.json");

                 // Registrar servicios de infraestructura con tu cadena construida
                 services.AddInfrastructureServices(connectionString);
             });
    }
}