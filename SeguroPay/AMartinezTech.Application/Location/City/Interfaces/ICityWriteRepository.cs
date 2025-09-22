using AMartinezTech.Domain.Location.Entities;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Location.City.Interfaces;

public interface ICityWriteRepository : ICreate<CityEntity>, IUpdate<CityEntity>, IDelete<Guid>;
