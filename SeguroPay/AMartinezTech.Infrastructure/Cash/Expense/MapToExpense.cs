using AMartinezTech.Domain.Cash.Expense;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Cash.Expense;

internal class MapToExpense
{
    internal static ExpenseEntity ToEntity(SqlDataReader reader)
    {
        var entity = ExpenseEntity.Create(
                  reader.GetGuid(reader.GetOrdinal("id")),
                  reader.GetDateTime(reader.GetOrdinal("created_at")),
                  reader.GetGuid(reader.GetOrdinal("category_id")),
                  reader.GetDecimal(reader.GetOrdinal("amount")),
                  reader.GetString(reader.GetOrdinal("note")),
                  reader.GetBoolean(reader.GetOrdinal("is_active")),
                  reader.GetGuid(reader.GetOrdinal("category_by")));

        entity.SetCategoryName(reader.GetString(reader.GetOrdinal("category_name")));

        return entity;
    }
}
