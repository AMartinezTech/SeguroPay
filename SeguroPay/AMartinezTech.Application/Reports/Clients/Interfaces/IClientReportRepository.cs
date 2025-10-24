using AMartinezTech.Application.Reports.Clients.Dtos;

namespace AMartinezTech.Application.Reports.Clients.Interfaces;

public interface IClientReportRepository
{
    Task<IReadOnlyList<ClientStatusProjection>> GetAllClientStatusAsync();
}
