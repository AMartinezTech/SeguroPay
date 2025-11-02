using System.Data;

namespace AMartinezTech.Application.Client.Interfaces;

public interface IClientReportRepository
{
    Task<DataTable> GetByFilterReportsAsync();  
}
