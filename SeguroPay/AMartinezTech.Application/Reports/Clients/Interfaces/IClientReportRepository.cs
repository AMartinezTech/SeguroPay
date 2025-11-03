using AMartinezTech.Application.Reports.Clients.Dtos;
using System.Data;

namespace AMartinezTech.Application.Reports.Clients.Interfaces;

public interface IClientReportRepository
{
    Task<IReadOnlyList<ClientStatusProjection>> GetAllClientStatusAsync();
    Task<DataTable> GetByFilterReportsAsync(Dictionary<string, object?>? filters = null);
}
