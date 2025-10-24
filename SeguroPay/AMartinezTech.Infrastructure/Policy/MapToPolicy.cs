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
            reader.GetString(reader.GetOrdinal("payment_method")),
            reader.GetInt32(reader.GetOrdinal("payment_day")),
            reader.GetInt32(reader.GetOrdinal("payment_installment")),
            reader.GetDecimal(reader.GetOrdinal("amount")),
            reader.GetString(reader.GetOrdinal("note")),
            reader.GetDateTime(reader.GetOrdinal("created_at")));

        entity.SetStatus(reader.GetString(reader.GetOrdinal("status")));

        entity.SetPropertiesIdsNames(
            reader.GetString(reader.GetOrdinal("insurance_name")),
            reader.GetString(reader.GetOrdinal("client_name"))
            );
        return entity;
    }

    internal static IncomeEntity ToIncomeEntity(SqlDataReader reader)
    {
        return IncomeEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetDateTime(reader.GetOrdinal("created_at")),
            reader.GetDateTime(reader.GetOrdinal("created_at")),
            reader.GetGuid(reader.GetOrdinal("doc_id_related")),
            reader.GetString(reader.GetOrdinal("income_type")),
            reader.GetString(reader.GetOrdinal("payment_method")),
            reader.GetString(reader.GetOrdinal("created_by")),
            reader.GetGuid(reader.GetOrdinal("doc_id_related")),
            reader.GetDecimal(reader.GetOrdinal("amount")) 
            );
    
    }

}
