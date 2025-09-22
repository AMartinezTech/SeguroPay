using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Location.Entities;

namespace AMartinezTech.Application.Location.City.Interfaces;

public interface ICityReadRepository : IPagination<CityEntity>
{
    Task<IReadOnlyList<CityEntity>> GetByRegionId(Guid regionId);
} 
