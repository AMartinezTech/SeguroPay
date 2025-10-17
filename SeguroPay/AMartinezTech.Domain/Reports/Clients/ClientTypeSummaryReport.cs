using AMartinezTech.Domain.Client.Entitties;
namespace AMartinezTech.Domain.Reports.Clients;

public class ClientTypeSummaryReport
{
    public IReadOnlyList<ClientTypeSummary> Summary { get; }
    public ClientTypeSummaryReport(IEnumerable<ClientEntity> clients)
    {
        Summary = clients
         .GroupBy(c => c.ClientType.Type.ToString().ToLower())
         .Select(g => new ClientTypeSummary
         {
             ClientType = g.Key,
             ActiveCount = g.Count(c => c.IsActive),
             InactiveCount = g.Count(c => !c.IsActive)
         })
         .ToList()          // Convierte a List<ClientTypeSummary>
         .AsReadOnly();     // Lo hace IReadOnlyList<ClientTypeSummary>
    }

   
}
