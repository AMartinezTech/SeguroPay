using AMartinezTech.Domain.Cash.Expense;
using Microsoft.Data.SqlClient; 

namespace AMartinezTech.Infrastructure.Cash.Expense.Category;

internal class MapToExpenseCategory
{
    internal static ExpenseCategoryEntity ToEntity(SqlDataReader reader)
    {
        return ExpenseCategoryEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("name")),
            reader.GetBoolean(reader.GetOrdinal("is_active"))); 
    }
}
 