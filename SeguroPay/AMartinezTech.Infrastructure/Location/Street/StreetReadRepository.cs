using AMartinezTech.Application.Location.Street.Interfaces; 
using AMartinezTech.Domain.Location.Entities; 
using AMartinezTech.Domain.Utils.Exception; 
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Location.Street;

public class StreetReadRepository(string connectionString) : AdoRepositoryBase(connectionString), IStreetReadRepository
{
    public async Task<IReadOnlyList<StreetEntity>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? isActived = null)
    {
        var result = new List<StreetEntity>();
        using (var conn = GetConnection())
        {
            await conn.OpenAsync();


            using var cmd = new SqlCommand { Connection = conn };
                      
            var sql = $"SELECT TOP 100 * FROM streets ORDER BY city_id,street";
            cmd.CommandText = sql;

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                result.Add(MapToStreet.ToEntity(reader));
        }
        return result;
    }

    public async Task<IReadOnlyList<StreetEntity>> GetByCityId(Guid cityId)
    {
        try
        {
            List<StreetEntity>? entityList = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT *
                      FROM streets WHERE city_id=@city_id ORDER BY street";

            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@city_id", cityId);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entityList!.Add(MapToStreet.ToEntity(reader));
            }

            if (entityList == null) throw new DatabaseException($"{ErrorMessages.Get(ErrorType.RecordDoesDotExist)}"); 

            return entityList;
        }
        catch (SqlException ex)
        {
            var messaje = SqlErrorMapper.Map(ex);
            throw new DatabaseException(messaje);
        }
        catch (Exception) { throw; }
    }

    public async Task<StreetEntity> GetByIdAsync(Guid id)
    {
        try
        {
            StreetEntity? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT *
                      FROM streets WHERE id=@id";


            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity = MapToStreet.ToEntity(reader);
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
