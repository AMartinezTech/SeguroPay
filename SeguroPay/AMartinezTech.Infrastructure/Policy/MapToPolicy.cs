using AMartinezTech.Domain.Cash.Income;
using AMartinezTech.Domain.Policy;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Policy;

internal class MapToPolicy
{
    internal static PolicyEntity ToEntity(SqlDataReader reader)
    {

        var entity = PolicyEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("policy_no")),
            reader.GetString(reader.GetOrdinal("policy_type")),
            reader.GetGuid(reader.GetOrdinal("insurance_id")),
            reader.GetGuid(reader.GetOrdinal("clients_id")),
            reader.GetString(reader.GetOrdinal("payment_frencuency")), 
            reader.GetInt32(reader.GetOrdinal("payment_day")),
            reader.GetInt32(reader.GetOrdinal("payment_installment")),
            reader.GetDecimal(reader.GetOrdinal("amount")),
            reader.GetString(reader.GetOrdinal("note")),
            reader.GetDateTime(reader.GetOrdinal("created_at")));

        entity.SetStatus(reader.GetString(reader.GetOrdinal("status")));

        var lastPayment = reader.IsDBNull(reader.GetOrdinal("last_payment")) ? (DateTime?)null  : reader.GetDateTime(reader.GetOrdinal("last_payment"));

        entity.SetAnotherProperties(
            reader.GetString(reader.GetOrdinal("insurance_name")),
            reader.GetString(reader.GetOrdinal("client_name")),
           lastPayment
            );
        return entity;
    }

    internal static IncomeEntity ToIncomeEntity(SqlDataReader reader)
    {
        return IncomeEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetDateTime(reader.GetOrdinal("created_at")),
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

    }

}
