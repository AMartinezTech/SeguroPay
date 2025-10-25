using AMartinezTech.Domain.Cash.Income;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Cash.Income;

internal class MapToIncome
{
    internal static IncomeEntity ToEntity(SqlDataReader reader)
    {
        var entity = IncomeEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetDateTime(reader.GetOrdinal("payment_date")),
            reader.GetDateTime(reader.GetOrdinal("created_at")),
            reader.GetGuid(reader.GetOrdinal("policy_id")),
            reader.GetGuid(reader.GetOrdinal("client_id")),
            reader.GetString(reader.GetOrdinal("income_type")),
            reader.GetString(reader.GetOrdinal("payment_method")),
            reader.GetString(reader.GetOrdinal("made_in")),
            reader.GetGuid(reader.GetOrdinal("created_by")),
            reader.GetDecimal(reader.GetOrdinal("amount")),
            reader.GetString(reader.GetOrdinal("note")) 
            );

        entity.SetOpcionalProperties(reader.GetString(reader.GetOrdinal("client_name")),
            reader.GetString(reader.GetOrdinal("type_name")));

        return entity;
    }
}
