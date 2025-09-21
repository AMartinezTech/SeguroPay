using AMartinezTech.Domain.Client.Entitties;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Application.Client.UseCases.Writer;

public class ClientUpdate(IClientWriteRepository repository)
{
    private readonly IClientWriteRepository _repository = repository;
    public async Task UpdateAsync(ClientDto dto)
    {
        var address = ValueAddress.Create(dto.CountryId, dto.RegionId, dto.CityId, dto.PostalCodeId, dto.StreetId);

        var client = ClientEntity.Create(
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
        await _repository.UpdateAsync(client);

    }
}
