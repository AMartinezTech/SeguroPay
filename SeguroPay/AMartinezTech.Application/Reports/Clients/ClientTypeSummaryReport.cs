using AMartinezTech.Application.Reports.Clients.Dtos; 
using AMartinezTech.Domain.Utils.Enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AMartinezTech.Application.Reports.Clients;

public class ClientTypeSummaryReport
{

    public IReadOnlyList<ReportClientTypeSummary> Summary { get; }
    public ClientTypeSummaryReport(IEnumerable<ClientStatusProjection> clients)
    {
        Summary = clients
         .GroupBy(c => c.ClientType)
         .Select(g =>
         {

             if (Enum.TryParse<ClientTypes>(g.Key, out var enumValue))
             {
                 return new ReportClientTypeSummary
                 {
                     ClientType = GetDisplayName(enumValue),
                     ActiveCount = g.Count(c => c.IsActive),
                     InactiveCount = g.Count(c => !c.IsActive)
                 };
             }
             return new ReportClientTypeSummary
             {

                 ClientType = g.Key,
                 ActiveCount = g.Count(c => c.IsActive),
                 InactiveCount = g.Count(c => !c.IsActive)
             };
         })
         .ToList()          // Convierte a List<ClientTypeSummary>
         .AsReadOnly();     // Lo hace IReadOnlyList<ClientTypeSummary>
    }

    private static string GetDisplayName(Enum value)
    {
        return value.GetType()
                    .GetField(value.ToString())?
                    .GetCustomAttribute<DisplayAttribute>()?
                    .GetName()
                ?? value.ToString();
    }
}
