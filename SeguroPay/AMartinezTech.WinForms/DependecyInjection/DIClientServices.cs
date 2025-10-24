using AMartinezTech.Application.Client;
using AMartinezTech.Application.Client.Conversation;
using AMartinezTech.Application.Reports.Clients;
using AMartinezTech.Application.Reports.Clients.Interfaces;
using AMartinezTech.WinForms.Client;
using AMartinezTech.WinForms.Client.Conversations;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependecyInjection;

public class DIClientServices
{
    public static void Add(IServiceCollection services)
    {
        services.AddTransient<IClientReportService, ClientReportService>();

        services.AddTransient<FrmSelectClientView>();
        services.AddTransient<FrmClientDashboardView>();
        services.AddTransient<FrmClientView>();
        services.AddTransient<ClientController>();
        services.AddTransient<ClientAppServices>();

        // Client Conversations 
        services.AddTransient<ClientConversationAppService>();
        services.AddTransient<FrmClientConversationView>();

    }
}
