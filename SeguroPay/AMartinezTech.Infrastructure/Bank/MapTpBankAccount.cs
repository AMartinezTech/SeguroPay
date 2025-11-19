using AMartinezTech.Domain.Bank;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Bank;

internal static class MapToBankAccount
{
    internal static BankAccountEntity ToEntity(SqlDataReader reader)
    {
        return BankAccountEntity.Create(
            reader.GetGuid(reader.GetOrdinal("id")),
            reader.GetDateTime(reader.GetOrdinal("created_at")),
            reader.GetString(reader.GetOrdinal("name")),
            reader.GetString(reader.GetOrdinal("number")),
            reader.GetString(reader.GetOrdinal("type")),
            reader.GetString(reader.GetOrdinal("contact_name")),
            reader.GetString(reader.GetOrdinal("contact_phone")),
            reader.GetBoolean(reader.GetOrdinal("is_active"))
            );
    }

   }
