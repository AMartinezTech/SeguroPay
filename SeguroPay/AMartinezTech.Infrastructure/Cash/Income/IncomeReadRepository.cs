using AMartinezTech.Application.Cash.Income;
using AMartinezTech.Domain.Cash.Income;
using AMartinezTech.Domain.Utils.Exception;
using AMartinezTech.Infrastructure.Data.Specifications;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Cash.Income;

public class IncomeReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IIncomeReadRepository
{
    public async Task<IReadOnlyList<IncomeEntity>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? search = null, Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null)
    {
        var result = new List<IncomeEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };

            var spec = new SqlFilterSpecification(filters, search, dateRanges);
            var whereClause = spec.BuildCondition(cmd);

            var sql = $@"
                        SELECT 
                            i.id, 
                            i.payment_date,
                            i.created_at, 
                            i.policy_id,
                            i.client_id,
                            i.income_type,
                            i.payment_method,
                            i.made_in,
                            i.amount,
                            i.created_by,
                            i.note,
                            c.first_name + ' ' + c.last_name AS client_name,
                            u.full_name,
                            CASE
                                WHEN i.policy_id IS NULL THEN 'Otros ingresos'
                                ELSE 'Seguro'
                            END AS type_name
                        FROM incomes i 
                        LEFT JOIN policies p ON i.policy_id = p.id
                        LEFT JOIN insurances ins ON p.insurance_id = ins.id
                        INNER JOIN clients c ON i.client_id = c.id
                        INNER JOIN users u ON i.created_by = u.id
                        {whereClause} ORDER BY i.created_by DESC;";
            cmd.CommandText = sql;

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                result.Add(MapToIncome.ToEntity(reader));
        }
        return result;
    }

    public async Task<IncomeEntity?> GetByIdAsync(Guid id)
    {
        try
        {
            IncomeEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = $@"
                        SELECT 
                             i.id, 
                            i.payment_date,
                            i.created_at, 
                            i.policy_id,
                            i.client_id,
                            i.income_type,
                            i.payment_method,
                            i.made_in,
                            i.amount,
                            i.created_by,
                            i.note,
                            c.first_name + ' ' + c.last_name AS client_name,
                            u.full_name,
                            CASE
                                WHEN i.policy_id IS NULL THEN 'Otros ingresos'
                                ELSE 'Seguro'
                            END AS type_name
                        FROM incomes i 
                        LEFT JOIN policies p ON i.policy_id = p.id
                        LEFT JOIN insurances ins ON p.insurance_id = ins.id
                        INNER JOIN clients c ON i.client_id = c.id
                        INNER JOIN users u ON i.created_by = u.id
                        WHERE i.id=@id ORDER BY i.created_by DESC"; 

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToIncome.ToEntity(reader);
            }

            if (entity == null) throw new DatabaseException($"{ErrorMessages.Get(ErrorType.RecordDoesDotExist)}"); ;


            return entity;


        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception) { throw; }
    }
}
