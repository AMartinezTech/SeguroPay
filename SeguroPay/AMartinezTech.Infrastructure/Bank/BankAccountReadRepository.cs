using AMartinezTech.Application.Bank;
using AMartinezTech.Domain.Bank; 
using AMartinezTech.Infrastructure.Data.Specifications;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient; 

namespace AMartinezTech.Infrastructure.Bank;

public class BankAccountReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IBankAccountReadRepository
{
    public async Task<IReadOnlyList<BankAccountEntity>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? search = null, Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null)
    {
        var result = new List<BankAccountEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };

            var spec = new SqlFilterSpecification(filters, search, dateRanges);
            var whereClause = spec.BuildCondition(cmd);

            var sql = $@"
                        SELECT 
                          *
                        FROM bank_accounts  
                        {whereClause} ORDER BY created_at DESC;";
            cmd.CommandText = sql;

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                result.Add(MapToBankAccount.ToEntity(reader));
        }
        return result;
    }

    public async Task<BankAccountEntity?> GetByIdAsync(Guid id)
    {
        BankAccountEntity result;

        // 1) Cargar la cuenta bancaria
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            var sql = @"
                SELECT *
                FROM bank_accounts
                WHERE id = @Id";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = await cmd.ExecuteReaderAsync();

            if (!reader.HasRows)
                return null;

            result = MapToBankAccount.ToEntity(reader);
        }

        // 2) Cargar los movimientos de esa cuenta
        using (var connMov = GetConnection())
        {
            await connMov.OpenAsync();

            var sqlMov = @"
                SELECT m.id, m.bank_account_id, m.created_at, m.type, m.amount, m.description, m.created_by, u.full_name as user_name
                FROM bank_account_movements m
                INNER JOIN users u ON m.created_by = u.id
                WHERE bank_account_id = @BankAccountId";

            using var cmdMov = new SqlCommand(sqlMov, connMov);
            cmdMov.Parameters.AddWithValue("@BankAccountId", id);

            using var readerMov = await cmdMov.ExecuteReaderAsync();

            while (await readerMov.ReadAsync())
            { 
                // Usa método interno para agregar movimientos
                result!.AddMovement(
                   readerMov.GetDateTime(readerMov.GetOrdinal("created_at")),
                   readerMov.GetString(readerMov.GetOrdinal("type")),
                   readerMov.GetDecimal(readerMov.GetOrdinal("amount")),
                   readerMov.IsDBNull(readerMov.GetOrdinal("description"))
                ? null
                : readerMov.GetString(readerMov.GetOrdinal("description")),
                   readerMov.GetGuid(readerMov.GetOrdinal("created_by")),
                 readerMov.GetString(readerMov.GetOrdinal("user_name"))
                );
            }
        }
        return result;
    }
}
