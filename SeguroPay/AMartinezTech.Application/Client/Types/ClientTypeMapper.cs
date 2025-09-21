using AMartinezTech.Domain.Client.Entitties;

namespace AMartinezTech.Application.Client.Types;

internal class ClientTypeMapper
{
    public static ClientTypeDto ToDto(ClientTypeEntity clientType)
    {
        return new ClientTypeDto
        {
            Id = clientType.Id,
            Name = clientType.Name,
            IsActived = clientType.IsActived,
        };
    }

    public static List<ClientTypeDto> ToDtoList(IEnumerable<ClientTypeEntity> clientTypes)
    {
        return [.. clientTypes.Select(ToDto)];
    }
}
