using AMartinezTech.Domain.Location.Entities;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Location.Region.Interfaces;

public interface IRegionReadRepository : IPagination<RegionEntity>
{
    Task<IReadOnlyList<RegionEntity>> GetByCountryId(Guid countryId);

};
