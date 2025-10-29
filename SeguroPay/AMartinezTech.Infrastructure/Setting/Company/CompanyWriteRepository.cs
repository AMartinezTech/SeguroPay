using AMartinezTech.Application.Setting.Company;
using AMartinezTech.Domain.Setting.Company;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AMartinezTech.Infrastructure.Setting.Company;

public class CompanyWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), ICompanyWriteRepository
{
    public async Task CreateAsync(CompanyEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };


            var sql = @"INSERT INTO companies (id, rnc, name, phone, email, line1, line2, logo) " +
                "VALUES (@Id, @RNC, @Name, @Phone, @Email, @Line1, @Line2, @Logo )";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", entity.Id); 
            cmd.Parameters.AddWithValue("@RNC", entity.RNC.Value);
            cmd.Parameters.AddWithValue("@Name", entity.Name.Value);
            cmd.Parameters.AddWithValue("@Phone", entity.Phone.Value);
            cmd.Parameters.AddWithValue("@Email", entity.Email.Value); 
            cmd.Parameters.AddWithValue("@Line1", entity.Line1.Value);
            cmd.Parameters.AddWithValue("@Line2", entity.Line2.Value);  
            cmd.Parameters.AddWithValue("@Logo", SqlDbType.VarBinary).Value = entity.Logo.ToArray();


            await cmd.ExecuteNonQueryAsync();

        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex)
        {
            throw new DatabaseException("Error inesperado en infraestructura. Creando registro.!", ex);
        }
    }

    public async Task UpdateAsync(CompanyEntity entity)
    {
        try
        {
            using var conn = GetConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand { Connection = conn };
             
            var sql = @"UPDATE companies SET rnc = @RNC, name = @Name, phone = @Phone, email = @Email, line1 = @Line1, line2 = @Line2, logo = @Logo 
                    WHERE id = @Id";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.Parameters.AddWithValue("@RNC", entity.RNC.Value);
            cmd.Parameters.AddWithValue("@Name", entity.Name.Value);
            cmd.Parameters.AddWithValue("@Phone", entity.Phone.Value);
            cmd.Parameters.AddWithValue("@Email", entity.Email.Value);
            cmd.Parameters.AddWithValue("@Line1", entity.Line1.Value);
            cmd.Parameters.AddWithValue("@Line2", entity.Line2.Value);
            cmd.Parameters.AddWithValue("@Logo", SqlDbType.VarBinary).Value = entity.Logo.ToArray();


            await cmd.ExecuteNonQueryAsync();

        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex)
        {
            throw new DatabaseException("Error inesperado en infraestructura. Actualizando registro.!", ex);
        }
    }
}
