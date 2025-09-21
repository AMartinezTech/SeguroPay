using AMartinezTech.Domain.Client.Entitties;

namespace AMartinezTech.Application.Client;

internal class ClientMapper
{
    public static ClientDto ToDto(ClientEntity entity)
    {
        return new ClientDto
        {
            Id = entity.Id,
            CategoryId = entity.CategoryId.Value,
            DocIdentityTypeId = entity.DocIdentityTypeId.Value,
            TypeId = entity.TypeId.Value,
            DocIdentity = entity.DocIdentity.Value,
            FirstName = entity.FirstName.Value,
            LastName = entity.LastName.Value,
            StreetId = entity.Address.StreetId,
            CityId = entity.Address.CityId,
            RegionId = entity.Address.RegionId,
            PostalCodeId = entity.Address.PostalCodeId,
            CountryId = entity.Address.CountryId,
            Phone = entity.Phone.Value,
            Email = entity.Email.Value,
            Observation = entity.Observation,
            LocationNo = entity.LocationNo,
            AddressRef = entity.AddressRef,
            ContactName = entity.ContactName,
            ContactPhone = entity.ContactPhone,
            IsActived = entity.IsActived
        };
    }

    public static List<ClientDto> ToDtoList(IEnumerable<ClientEntity> entities)
    {
        return [.. entities.Select(ToDto)];
    }
}
