using AMartinezTech.Domain.Location.Entities;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Location.Street.Interfaces;

public interface IStreetReadRepository : IFilter<StreetEntity>, IGetById<StreetEntity,Guid>
{
    Task<IReadOnlyList<StreetEntity>> GetByCityId(Guid cityId);
}