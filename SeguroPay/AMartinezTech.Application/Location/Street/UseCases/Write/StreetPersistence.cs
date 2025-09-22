using AMartinezTech.Application.Location.Street.Interfaces;
using AMartinezTech.Domain.Location.Entities;

namespace AMartinezTech.Application.Location.Street.UseCases.Write;

public class StreetPersistence(IStreetWriteRepository repository)
{
    private readonly IStreetWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(StreetDto dto)
    {
        var entity = StreetEntity.Create(
            dto.Id,
            dto.CityId,
            dto.Name,
            dto.CreatedAt);

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }

        return entity.Id;
    }
}

