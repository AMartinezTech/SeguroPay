using AMartinezTech.Application.Clients.DTOs;
using AMartinezTech.Application.Clients.Repositories;
using AMartinezTech.Domain.Clients.Entitties;

namespace AMartinezTech.Application.Clients;

public class ClientCommands(IClientWriteRepository repository)
{
    private readonly IClientWriteRepository _repository = repository;

    public async Task<Guid> CreateAsync(ClientDto dto)
    {
        var client = ClientEntity.Create(
            Guid.Empty,
            dto.CategoryId,
            dto.DocIdentityTypeId,
            dto.TypeId,
            dto.DocIdentity,
            dto.FirstName,
            dto.LastName,
            dto.StreetId,
            dto.CityId,
            dto.RegionId,
            dto.PostalCodeId,
            dto.CountryId,
            dto.Phone,
            dto.Email,
            dto.Observation ?? string.Empty,
            dto.LocationNo ?? string.Empty,
            dto.AddressRef ?? string.Empty,
            dto.IsActived
        );
        await _repository.CreateAsync(client);
        return client.Id;

    }

    public async Task  UpdateAsync(ClientDto dto)
    {
        var client = ClientEntity.Create(
            dto.Id,
            dto.CategoryId,
            dto.DocIdentityTypeId,
            dto.TypeId,
            dto.DocIdentity,
            dto.FirstName,
            dto.LastName,
            dto.StreetId,
            dto.CityId,
            dto.RegionId,
            dto.PostalCodeId,
            dto.CountryId,
            dto.Phone,
            dto.Email,
            dto.Observation ?? string.Empty,
            dto.LocationNo ?? string.Empty,
            dto.AddressRef ?? string.Empty,
            dto.IsActived
        );
        await _repository.UpdateAsync(client);
         

    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

}
