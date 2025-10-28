using AMartinezTech.Application.Utils.Interfaces;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Utils;

public class ServerTimeProvider(string connectionString) : AdoRepositoryBase(connectionString), IServerTimeProvider
{
    public async Task<DateTime> GetServerDateTimeAsync()
    {
        using var conn = GetConnection();
        await conn.OpenAsync();

        using var cmd = new SqlCommand { Connection = conn };
        var sql = @"SELECT SYSDATETIME()";
        cmd.CommandText = sql;
        var result = await cmd.ExecuteScalarAsync();
        return result != null ? (DateTime)result : DateTime.UtcNow;
    }
}
