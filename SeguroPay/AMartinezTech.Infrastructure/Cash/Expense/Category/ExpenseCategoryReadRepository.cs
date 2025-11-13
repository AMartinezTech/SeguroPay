using AMartinezTech.Application.Cash.Expense.Category;
using AMartinezTech.Domain.Cash.Expense;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exception;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Cash.Expense.Category;

public class ExpenseCategoryReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IExpenseCategoryReadRepository
{
    public async Task<ExpenseCategoryEntity?> GetByIdAsync(Guid id)
    {
        try
        {
            ExpenseCategoryEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT *
                      FROM expense_categories WHERE id=@id";


            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToExpenseCategory.ToEntity(reader);
            }

            if (entity == null) throw new DatabaseException($"{ErrorMessages.Get(ErrorType.RecordDoesDotExist)}"); ;


            return entity;


        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception) { throw; }
    }

    public async Task<PageResult<ExpenseCategoryEntity>> PaginationAsync(int pageNumber, int pageSize, bool? IsActive)
    {
        var result = new List<ExpenseCategoryEntity>();
        int totalRecords = 0;

        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // 1️⃣ Contar total de registros
            var countSql = "SELECT COUNT(*) FROM expense_categories WHERE 1=1";
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
                    FROM expense_categories
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
                result.Add(MapToExpenseCategory.ToEntity(reader));
        }

        return new PageResult<ExpenseCategoryEntity>(totalRecords, pageSize, result);
    }
}
