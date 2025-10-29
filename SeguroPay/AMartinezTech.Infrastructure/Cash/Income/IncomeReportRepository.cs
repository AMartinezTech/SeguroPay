using AMartinezTech.Application.Reports.Incomes.Interfaces;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AMartinezTech.Infrastructure.Cash.Income;

public class IncomeReportRepository(string connectionString) : AdoRepositoryBase(connectionString), IIncomeReportRepository
{
    public async Task<DataTable> GetIncomeReceiptAsync(Guid incomeId)
    {
        var dataTable = new DataTable("IncomeReceipt");
        using var conn = GetConnection();
        await conn.OpenAsync();

        var sql = @"
        SELECT 
            i.id AS IncomeId,
            p.policy_no AS PolicyNumber,
            ins.name AS InsuranceName,
            c.first_name + ' ' + c.last_name AS ClientName,
            c.phone AS ClientPhone,
            i.payment_date AS PaymentDate,
            i.amount AS Amount,
            i.payment_method AS PaymentMethod,
            i.note AS Note
        FROM incomes i
        LEFT JOIN policies p ON i.policy_id = p.id
        LEFT JOIN insurances ins ON p.insurance_id = ins.id
        INNER JOIN clients c ON i.client_id = c.id
        WHERE i.id = @IncomeId;";

        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@IncomeId", incomeId);

        using var adapter = new SqlDataAdapter(cmd);
        await Task.Run(() => adapter.Fill(dataTable));

        return dataTable;
    }
}
