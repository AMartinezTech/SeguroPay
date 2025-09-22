using AMartinezTech.Application.Location.City.Interfaces;
using AMartinezTech.Domain.Location.Entities;

namespace AMartinezTech.Application.Location.City.UseCases.Write;

public class CityPersistence(ICityWriteRepository repository)
{
    private readonly ICityWriteRepository _repository = repository;

    public async Task<Guid> PersistenceAsync(CityDto dto)
    {
        var entity = CityEntity.Create(
            dto.Id,
            dto.Name,
            dto.RegionId,
            dto.CreatedAt
            );

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }
        return entity.Id;

    }
}
