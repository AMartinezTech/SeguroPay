using AMartinezTech.Domain.Client.Entitties;

namespace AMartinezTech.Application.Client;

internal class ClientMapper
{
    public static ClientDto ToDto(ClientEntity client)
    {
        return new ClientDto
        {
            Id = client.Id,
            CategoryId = client.CategoryId.Value,
            DocIdentityTypeId = client.DocIdentityTypeId.Value,
            TypeId = client.TypeId.Value,
            DocIdentity = client.DocIdentity.Value,
            FirstName = client.FirstName.Value,
            LastName = client.LastName.Value,
            StreetId = client.Address.StreetId,
            CityId = client.Address.CityId,
            RegionId = client.Address.RegionId,
            PostalCodeId = client.Address.PostalCodeId,
            CountryId = client.Address.CountryId,
            Phone = client.Phone.Value,
            Email = client.Email.Value,
            Observation = client.Observation,
            LocationNo = client.LocationNo,
            AddressRef = client.AddressRef,
            ContactName = client.ContactName,
            ContactPhone = client.ContactPhone,
            IsActived = client.IsActived
        };
    }

    public static List<ClientDto> ToDtoList(IEnumerable<ClientEntity> clients)
    {
        return [.. clients.Select(ToDto)];
    }
}
