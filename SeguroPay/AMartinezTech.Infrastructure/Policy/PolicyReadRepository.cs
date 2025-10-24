using AMartinezTech.Application.Policy.Interfaces;
using AMartinezTech.Domain.Cash.Income;
using AMartinezTech.Domain.Policy;
using AMartinezTech.Domain.Utils.Exception;
using AMartinezTech.Infrastructure.Data.Specifications;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Policy;

public class PolicyReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IPolicyReadRepository
{
    public async Task<bool> ExistsByClientAndTypeAsync(Guid clientId, string policyType)
    {

        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };

            var sql = @"SELECT COUNT(*) 
                FROM policies 
                WHERE clients_id = @ClientId AND policy_type = @PolicyType AND status != @Status";
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@ClientId", clientId);
            cmd.Parameters.AddWithValue("@PolicyType", policyType);
            cmd.Parameters.AddWithValue("@Status", "Canceled");

            var count = Convert.ToInt32(await cmd.ExecuteScalarAsync());

            return count > 0;
        }
        catch (SqlException ex)
        {
            var message = SqlErrorMapper.Map(ex);
            throw new DatabaseException(message);
        }
        catch (Exception)
        {
            throw;
        }

    }

    public async Task<bool> ExistsByPolicyNoAsync(string policyNo)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };

            var sql = @"SELECT COUNT(*) FROM policies WHERE policy_no = @PolicyNo AND status != @Status";
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@PolicyNo", policyNo);
            cmd.Parameters.AddWithValue("@Status", "Canceled");


            var count = Convert.ToInt32(await cmd.ExecuteScalarAsync());

            return count > 0;
        }
        catch (SqlException ex)
        {
            var message = SqlErrorMapper.Map(ex);
            throw new DatabaseException(message);
        }
        catch (Exception)
        {
            throw;
        }

    }

    public async Task<IReadOnlyList<PolicyEntity>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? search = null, Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null)
    {
        var result = new List<PolicyEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            using var cmd = new SqlCommand { Connection = conn };

            var spec = new SqlFilterSpecification(filters, search, dateRanges);
            var whereClause = spec.BuildCondition(cmd);

            var sql = $@"SELECT TOP 250 
                p.id, 
                p.policy_no, 
                p.created_at,
                p.policy_type, 
                i.name AS insurance_name,
                CONCAT(c.first_name, ' ', c.last_name) AS client_name, 
                p.payment_frencuency, 
                p.payment_day, 
                p.amount, 
                p.note, 
                p.status, 
                i.id AS insurance_id,
                c.id AS clients_id,
                c.doc_identity AS doc_identity,
                p.payment_method,
                p.payment_installment
                FROM policies p
                INNER JOIN insurances i ON p.insurance_id = i.id 
                INNER JOIN clients c ON p.clients_id = c.id 
                {whereClause} ORDER BY p.created_at DESC;";
            cmd.CommandText = sql;

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                result.Add(MapToPolicy.ToEntity(reader));
        }
        return result;
    }



    public async Task<PolicyEntity?> GetByIdAsync(Guid id)
    {
        try
        {
            PolicyEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

           

            var sql = $@"SELECT TOP 250 
               p.id, 
                p.policy_no, 
                p.created_at,
                p.policy_type, 
                i.name AS insurance_name,
                CONCAT(c.first_name, ' ', c.last_name) AS client_name, 
                p.payment_frencuency, 
                p.payment_day, 
                p.amount, 
                p.note, 
                p.status, 
                i.id AS insurance_id,
                c.id AS clients_id,
                c.doc_identity AS doc_identity,
                p.payment_method,
                p.payment_installment
                FROM policies p 
                INNER JOIN insurances i ON p.insurance_id = i.id 
                INNER JOIN clients c ON p.clients_id = c.id 
                WHERE p.id=@id ORDER BY p.created_at DESC;";


            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToPolicy.ToEntity(reader);
            }

            if (entity == null) throw new DatabaseException($"{ErrorMessages.Get(ErrorType.RecordDoesDotExist)}"); ;


            // =================================
            // 2️⃣ OBTENER PAGOS RELACIONADOS
            // =================================
            var incomes = new List<IncomeEntity>();

            var sqlIncomes = @"
            SELECT 
                id,
                payment_date,
                created_at,
                doc_id_related,
                income_type,
                payment_method,
                made_id,
                created_by,
                amount
            FROM incomes
            WHERE doc_id_related = @policyId
            AND type = 'Insured'
            ORDER BY created_at ASC;";

            using (var cmdIncome = new SqlCommand(sqlIncomes, conn))
            {
                cmdIncome.Parameters.AddWithValue("@policyId", id);

                using var readerIncome = await cmdIncome.ExecuteReaderAsync();
                while (await readerIncome.ReadAsync())
                    incomes.Add(MapToPolicy.ToIncomeEntity(readerIncome));
            }

            // =================================
            // 3️⃣ ASOCIAR LOS PAGOS A LA POLIZA
            // =================================
            foreach (var income in incomes)
            {
                entity.AddPayment(
                    income.Id,
                    income.PaymentDate,
                    income.CreatedAt,
                    income.DocIdRelated, 
                    income.IncomeType.ToString(), 
                    income.PaymentMethod.ToString(), 
                    income.MadeIn.ToString(), 
                    income.CreatedBy,
                    income.Amount
                     
                );
            }

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
