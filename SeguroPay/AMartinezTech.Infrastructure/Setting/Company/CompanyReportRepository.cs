using AMartinezTech.Application.Reports.Companies;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient; 
using System.Data;

namespace AMartinezTech.Infrastructure.Setting.Company;

public class CompanyReportRepository(string connectionString) : AdoRepositoryBase(connectionString), ICompanyReportRepository
{ 
    public async Task<DataTable> GetReportsAsync()
    {
        var dataTable = new DataTable("Company");
        using var conn = GetConnection();
        await conn.OpenAsync();

        var sql = @"SELECT TOP 1 * FROM companies ";

        using var cmd = new SqlCommand(sql, conn); 

        using var adapter = new SqlDataAdapter(cmd);
        await Task.Run(() => adapter.Fill(dataTable));

        return dataTable;
    }
}
