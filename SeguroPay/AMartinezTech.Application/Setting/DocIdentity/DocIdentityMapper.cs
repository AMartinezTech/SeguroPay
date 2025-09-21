 
using AMartinezTech.Domain.Setting.DocIndentity;

namespace AMartinezTech.Application.Setting.DocIdentity;

public class DocIdentityMapper
{
    public static DocIdentityDto ToDto(DocIdentityEntity docIdentity)
    {
        return new DocIdentityDto
        {
            Id = docIdentity.Id,
            Name = docIdentity.Name,
            IsActived = docIdentity.IsActived,
        };
    }

    public static List<DocIdentityDto> ToDtoList(IEnumerable<DocIdentityEntity> docIdentities)
    {
        return [.. docIdentities.Select(ToDto)];
    }
}
