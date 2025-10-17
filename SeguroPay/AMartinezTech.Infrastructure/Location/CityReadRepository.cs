using Microsoft.Data.SqlClient;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exception; 
using AMartinezTech.Domain.Location.Entities;
using AMartinezTech.Infrastructure.Utils.Exceptions;
using AMartinezTech.Infrastructure.Utils.Persistence;
using AMartinezTech.Application.Location.City.Interfaces; 

namespace AMartinezTech.Infrastructure.Location;

public class CityReadRepository(string connectionString) : AdoRepositoryBase(connectionString), ICityReadRepository
{
    public async Task<IReadOnlyList<CityEntity>> GetByRegionId(Guid regionId)
    {
        try
        {
            List<CityEntity>? entity = null;
            using var conn = GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT *
                      FROM cities WHERE region_id=@id ORDER BY order_position";


            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@region_id", regionId);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                entity!.Add( MapToCity.ToEntity(reader));
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

    public async Task<PageResult<CityEntity>> PaginationAsync(int pageNumber, int pageSize, bool? IsActive)
    {
        var result = new List<CityEntity>();
        int totalRecords = 0;

        using (var conn = GetConnection())
        {
            await conn.OpenAsync();

            // 1️⃣ Contar total de registros
            var countSql = "SELECT COUNT(*) FROM cities WHERE 1=1";
             

            using (var countCmd = new SqlCommand(countSql, conn))
            {
               

                totalRecords = Convert.ToInt32(await countCmd.ExecuteScalarAsync());
            }

            // 2️⃣ Traer página
            var sql = @"SELECT * 
                    FROM cities
                    WHERE 1=1";

            
            sql += @" ORDER BY order_position, name
                  OFFSET @offset ROWS 
                  FETCH NEXT @pageSize ROWS ONLY;";

            using var cmd = new SqlCommand(sql, conn);

          

            cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
            cmd.Parameters.AddWithValue("@pageSize", pageSize);

            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
                result.Add(MapToCity.ToEntity(reader));
        }

        return new PageResult<CityEntity>(totalRecords, pageSize, result);
    }
}
