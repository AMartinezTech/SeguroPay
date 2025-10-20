using AMartinezTech.Domain.Policy;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.Exception;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Policy;

internal class MapToPolicy
{
    internal static PolicyEntity ToEntity(SqlDataReader reader)
    {

        if (!Enum.TryParse(reader.GetString(reader.GetOrdinal("pay_frencuency")), out PolicyPayFrencuency payFrecuency)) throw new Exception($"{ErrorMessages.Get(ErrorType.InvalidType)} (Infrastructure) - PayFrencuency");
        if (!Enum.TryParse(reader.GetString(reader.GetOrdinal("status")), out PolicyStatusType status)) throw new Exception($"{ErrorMessages.Get(ErrorType.InvalidType)} (Infrastructure) - Status");
       
        return PolicyEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetString(reader.GetOrdinal("policy_no")),
            reader.GetGuid(reader.GetOrdinal("policy_type_id")),
            reader.GetGuid(reader.GetOrdinal("ensurance_id")),
            reader.GetGuid(reader.GetOrdinal("client_id")),
            payFrecuency,
            reader.GetInt32(reader.GetOrdinal("pay_day")),
            reader.GetDecimal(reader.GetOrdinal("amount")),
            reader.GetString(reader.GetOrdinal("note")),
            reader.GetDateTime(reader.GetOrdinal("created_at")),
            reader.GetDateTime(reader.GetOrdinal("updated_at")),
            status,
            reader.GetGuid(reader.GetOrdinal("created_by")),
            reader.GetString(reader.GetOrdinal("policy_type_name")),
            reader.GetString(reader.GetOrdinal("ensurance_name")),
            reader.GetString(reader.GetOrdinal("client_name"))
            );
    }
}
