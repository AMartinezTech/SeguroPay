using AMartinezTech.Application.Client.Conversation.Interfaces;
using AMartinezTech.Application.Client.Interfaces;
using AMartinezTech.Application.Reports.Clients.Interfaces;
using AMartinezTech.Infrastructure.Clients;
using AMartinezTech.Infrastructure.Clients.Conversations;
using Microsoft.Extensions.DependencyInjection;

namespace AMartinezTech.Infrastructure.Utils.DependencyInjection;

public static class DIClientServices
{
    public static IServiceCollection Add(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IClientWriteRepository>(sp => new ClientWriterRepository(connectionString));
        services.AddScoped<IClientReadRepository>(sp => new ClientReadRepository(connectionString));
        services.AddScoped<IClientReportRepository>(sp => new ClientReportRepository(connectionString));

        // Client Conversatios
        services.AddScoped<IClientConversationReadRepository>(sp => new ClientConversationReadRepository(connectionString));
        services.AddScoped<IClientConversationWriteRepository>(sp => new ClientConversationWriteRepository(connectionString));

        return services;
    }
}
