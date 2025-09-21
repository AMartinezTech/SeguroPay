using AMartinezTech.Application.Client.Interfaces;
using AMartinezTech.Domain.Client.Entitties;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Application.Client.UseCases.Write;

public class ClientPersistence(IClientWriteRepository repository)
{
    private readonly IClientWriteRepository _repository = repository;

    public async Task<Guid> PersistenceAsync(ClientDto dto)
    {
        var address = ValueAddress.Create(dto.CountryId, dto.RegionId, dto.CityId, dto.PostalCodeId, dto.StreetId);
        var entity = ClientEntity.Create(
            dto.Id,
            dto.CategoryId,
            dto.DocIdentityTypeId,
            dto.TypeId,
            dto.DocIdentity,
            dto.FirstName,
            dto.LastName,
            address,
            dto.Phone,
            dto.Email,
            dto.Observation ?? string.Empty,
            dto.LocationNo ?? string.Empty,
            dto.AddressRef ?? string.Empty,
            dto.IsActived,
            dto.ContactName ?? string.Empty,
            dto.ContactPhone ?? string.Empty
        );
        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }
        return entity.Id;

    }
}
