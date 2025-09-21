using AMartinezTech.Domain.Client.Entitties;

namespace AMartinezTech.Application.Client;

public class ClientMapper
{
    public static ClientDto ToDto(ClientEntity client)
    {
        return new ClientDto
        {
            Id = client.Id,
            CategoryId = client.CategoryId,
            DocIdentityTypeId = client.DocIdentityTypeId,
            TypeId = client.TypeId,
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
            IsActived = client.IsActived
        };
    }

    public static List<ClientDto> ToDtoList(IEnumerable<ClientEntity> clients)
    {
        return [.. clients.Select(ToDto)];
    }
}
