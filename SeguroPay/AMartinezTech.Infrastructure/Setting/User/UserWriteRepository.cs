using AMartinezTech.Application.Setting.User.Interfaces;
using AMartinezTech.Domain.Setting.User;
using AMartinezTech.Domain.Utils.Exception;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Setting.User;

public class UserWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), IUserWriteRepository
{
    public async Task CreateAsync(UserEntity entity)
    {
        try
        {

            using var conn = GetConnection();
            await conn.OpenAsync();
            string sql = @"INSERT INTO users (id, user_name, email, password, full_name, phone, rol, is_actived) 
                        VALUES(@id, @user_name, @email, @password, @full_name, @phone, @rol, @is_actived)";
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@user_name", entity.UserName.Value);
            cmd.Parameters.AddWithValue("@email", entity.Email.Value);
            cmd.Parameters.AddWithValue("@password", entity.Password.Hash);
            cmd.Parameters.AddWithValue("@full_name", entity.FullName.Value);
            cmd.Parameters.AddWithValue("@phone", entity.Phone.Value);
            cmd.Parameters.AddWithValue("@rol", entity.Rol.Type);
            cmd.Parameters.AddWithValue("@is_actived", entity.IsActived);

            await cmd.ExecuteNonQueryAsync();
        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex) { throw new DatabaseException($"{ErrorMessages.Get(ErrorType.DataBaseUnknownError)}", ex); }
    }

    public async Task UpdateAsync(UserEntity entity)
    {
        try
        {

            using var conn = GetConnection();
            await conn.OpenAsync();
            string sql = @"UPDATE users SET full_name=@full_name, phone=@phone, rol=@rol, is_actived=@is_actived) 
                          WHERE id=@id";
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", entity.Id); 
            cmd.Parameters.AddWithValue("@full_name", entity.FullName.Value);
            cmd.Parameters.AddWithValue("@phone", entity.Phone.Value);
            cmd.Parameters.AddWithValue("@rol", entity.Rol.Type);
            cmd.Parameters.AddWithValue("@is_actived", entity.IsActived);

            await cmd.ExecuteNonQueryAsync();
        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception ex) { throw new DatabaseException($"{ErrorMessages.Get(ErrorType.DataBaseUnknownError)}", ex); }
    }
}
