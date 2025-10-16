using AMartinezTech.Application.Client;
using AMartinezTech.Application.Client.Conversation;
using AMartinezTech.Application.Reports.Clients;
using AMartinezTech.WinForms.Client;
using AMartinezTech.WinForms.Client.Conversations;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.WinForms.DependecyInjection;

public class DIClientServices
{
    public static void Add(IServiceCollection services)
    {
        services.AddTransient<ClientReportService>();

        services.AddTransient<FrmClientDashboardView>();
        services.AddTransient<FrmClientView>();
        services.AddTransient<ClientController>();
        services.AddTransient<ClientApplicationService>();

        // Client Conversations 
        services.AddTransient<ClientConversationApplicationService>();
        services.AddTransient<FrmClientConversationView>();

    }
}
