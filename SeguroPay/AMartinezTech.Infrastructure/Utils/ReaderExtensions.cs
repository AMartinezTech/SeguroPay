using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Utils;

public static class ReaderExtensions
{
    public static string GetSafeString(this SqlDataReader reader, string column)
    {
        var index = reader.GetOrdinal(column);
        return reader.IsDBNull(index) ? "" : reader.GetString(index);
    }

    public static DateTime GetSafeDateTime(this SqlDataReader reader, string column)
    {
        var index = reader.GetOrdinal(column);
        return reader.IsDBNull(index) ? DateTime.MinValue : reader.GetDateTime(index);
    }
}
