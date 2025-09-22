using AMartinezTech.Application.Insurance.Interfaces;
using AMartinezTech.Domain.Insurance;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Application.Insurance.UseCases.Write;

public class InsurancePersistence(IInsuranceWriteRepository repository)
{
    private readonly IInsuranceWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(InsuranceDto dto)
    {

        var address = ValueAddress.Create(dto.CountryId, dto.RegionId, dto.CityId, dto.StreetId);
        var entity = InsuranceEntity.Create(
            dto.Id,
            dto.CreatedAt,
            dto.Name,
            address,
            dto.Email,
            dto.Phone,
            dto.ContactName ?? string.Empty,
            dto.ContactPhone ?? string.Empty,
            dto.IsActived
            );

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }

        return entity.Id;
    }
}
