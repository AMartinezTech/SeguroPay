using AMartinezTech.Domain.Client.Entitties;

namespace AMartinezTech.Application.Client;

internal class ClientMapper
{
    public static ClientDto ToDto(ClientEntity entity)
    {
        return new ClientDto
        {
            Id = entity.Id,
            DocIdentityType = entity.DocIdentityType.Type.ToString(),
            ClientType = entity.ClientType.Type.ToString(),
            DocIdentity = entity.DocIdentity,
            FirstName = entity.FirstName.Value,
            LastName = entity.LastName.Value,
            StreetId = entity.StreetId,
            CityId = entity.CityId, 
            Phone = entity.Phone,
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
        return [.. entities.Select(ToDto).ToList()];
    }
}
