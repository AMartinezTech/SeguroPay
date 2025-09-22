using AMartinezTech.Domain.Location.Entities;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Location.Street.Interfaces;

public interface IStreetReadRepository : IPagination<StreetEntity>, IFilter<StreetEntity>
{
    Task<IReadOnlyList<StreetEntity>> GetByCityId(Guid cityId);
}