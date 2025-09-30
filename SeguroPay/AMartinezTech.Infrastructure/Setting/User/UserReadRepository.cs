using AMartinezTech.Application.Setting.User.Interfaces;
using AMartinezTech.Domain.Setting.User;
using AMartinezTech.Domain.Utils.Exception;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Setting.User;

public class UserReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IUserReadRepository
{
    public async Task<IReadOnlyList<UserEntity>> FilterAsync(string? filterStr, bool? isActived)
    {
        var result = new List<UserEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // Base query
            var sql = @"SELECT TOP 100 id, user_name, email, password, full_name, phone, rol, is_actived, created_at FROM users WHERE 1=1";

            if (isActived.HasValue)
                sql += " AND is_actived=@is_actived";

            if (!string.IsNullOrWhiteSpace(filterStr))
                sql += " AND (user_name LIKE @filter OR name LIKE @filter)";

            using var cmd = new SqlCommand(sql, conn);

            if (isActived.HasValue)
                cmd.Parameters.AddWithValue("@is_actived", isActived);

            if (!string.IsNullOrWhiteSpace(filterStr))
                cmd.Parameters.AddWithValue("@filter", $"%{filterStr}%");

            using var reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
                result.Add(MapToUser.ToEntity(reader));
        }
        return result;
    }

    public async Task<UserEntity> GetByIdAsync(Guid id)
    {
        try
        {
            UserEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT id, user_name, email, password, full_name, phone, rol, is_actived, created_at
                      FROM users WHERE id=@id";


            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToUser.ToEntity(reader);
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

    public async Task<UserEntity> LoginAsync(string userName, string password)
    {
        try
        {
            UserEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT id, user_name, email, password, full_name, phone, rol, is_actived, created_at
                    FROM users 
                    WHERE user_name = @user_name";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@user_name", userName);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToUser.ToEntity(reader);
            }

            if (entity == null) throw new Exception($"{ErrorMessages.Get(ErrorType.InvalidCredentials)} - NoExistUser");

            if (!entity.IsActived) throw new Exception($"{ErrorMessages.Get(ErrorType.InvalidCredentials)} - NoActivedUse");

            if (!entity.Password.Verify(password)) throw new Exception($"{ErrorMessages.Get(ErrorType.InvalidCredentials)} - PassNotMach");

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
