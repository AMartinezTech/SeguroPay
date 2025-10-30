using AMartinezTech.Domain.Setting.Company;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Setting.Company;

internal class MapToCompany
{
    internal static CompanyEntity ToEntity(SqlDataReader reader)
    {
        // Obtener el stream del logo (si existe)
        MemoryStream? logoStream = null;

        int logoOrdinal = reader.GetOrdinal("logo");
        if (!reader.IsDBNull(logoOrdinal))
        {
            // Convertir VARBINARY a MemoryStream
            byte[] logoBytes = (byte[])reader["logo"];
            logoStream = new MemoryStream(logoBytes);
        }

        return CompanyEntity.Create(
           reader.GetGuid(reader.GetOrdinal("id")),
           reader.GetDateTime(reader.GetOrdinal("created_at")),
           reader.GetString(reader.GetOrdinal("name")),
           reader.GetString(reader.GetOrdinal("rnc")),
           reader.GetString(reader.GetOrdinal("email")),
           reader.GetString(reader.GetOrdinal("phone")),
           reader.GetString(reader.GetOrdinal("line1")),
           reader.GetString(reader.GetOrdinal("line2")),
           reader.GetBoolean(reader.GetOrdinal("is_active")),
           logoStream);
         
    }
}
