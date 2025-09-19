using AMartinezTech.Domain.Clients.Entitties;

namespace AMartinezTech.Application.Clients;

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
            StreetId = client.StreetId,
            CityId = client.CityId,
            RegionId = client.RegionId,
            PostalCodeId = client.PostalCodeId,
            CountryId = client.CountryId,
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
