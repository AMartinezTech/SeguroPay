using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Utils.Persistence;

public abstract class AdoRepositoryBase(string connectionString)
{
    protected readonly string _connectionString = connectionString;

    protected SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
