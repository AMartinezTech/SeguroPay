using Microsoft.Data.SqlClient;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Cash.Expense; 
using AMartinezTech.Infrastructure.Utils.Persistence;
using AMartinezTech.Infrastructure.Data.Specifications;
using AMartinezTech.Application.Cash.Expense.Interfaces;

namespace AMartinezTech.Infrastructure.Cash.Expense;

public class ExpenseReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IExpenseReadRepository
{
    public async Task<IReadOnlyList<ExpenseEntity>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? search = null, Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null)
    {
        var result = new List<ExpenseEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };

            var spec = new SqlFilterSpecification(filters, search, dateRanges);
            var whereClause = spec.BuildCondition(cmd);

            var sql = $@"
                        SELECT 
                           e.id,
                           e.created_at,
                           e.category_id,
                           e.amount,
                           e.note,
                           e.is_active,
                           ec.name AS category_name
                        FROM expenses e 
                        LEFT JOIN expense_categories ec ON e.category_id = ec.id
                        {whereClause} ORDER BY i.created_at DESC;";
            cmd.CommandText = sql;

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                result.Add(MapToExpense.ToEntity(reader));
        }
        return result;
    }

    public async Task<PageResult<ExpenseEntity>> PaginationAsync(int pageNumber, int pageSize, bool? IsActive)
    {
        var result = new List<ExpenseEntity>();
        int totalRecords = 0;

        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // 1️⃣ Contar total de registros
            var countSql = "SELECT COUNT(*) FROM expenses WHERE 1=1";
            if (IsActive.HasValue)
                countSql += " AND is_active = @is_active";

            using (var countCmd = new SqlCommand(countSql, conn))
            {
                if (IsActive.HasValue)
                    countCmd.Parameters.AddWithValue("@is_active", IsActive.Value);

                totalRecords = Convert.ToInt32(await countCmd.ExecuteScalarAsync());
            }

            // 2️⃣ Traer página
            var sql = @"SELECT * 
                    FROM expenses
                    WHERE 1=1";

            if (IsActive.HasValue)
                sql += " AND is_active = @is_active";

            sql += @" ORDER BY name
                  OFFSET @offset ROWS 
                  FETCH NEXT @pageSize ROWS ONLY;";

            using var cmd = new SqlCommand(sql, conn);

            if (IsActive.HasValue)
                cmd.Parameters.AddWithValue("@is_active", IsActive.Value);

            cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
            cmd.Parameters.AddWithValue("@pageSize", pageSize);

            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
                result.Add(MapToExpense.ToEntity(reader));
        }

        return new PageResult<ExpenseEntity>(totalRecords, pageSize, result);
    }
}
