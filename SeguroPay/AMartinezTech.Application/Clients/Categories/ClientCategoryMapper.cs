using AMartinezTech.Domain.Clients.Entitties;

namespace AMartinezTech.Application.Clients.Categories;

public class ClientCategoryMapper
{
    public static ClientCategoryDto ToDto(ClientCategoryEntity clientCategory)
    {
        return new ClientCategoryDto
        {
            Id = clientCategory.Id,
            Name = clientCategory.Name,
            IsActived = clientCategory.IsActived,
        };
    }

    public static List<ClientCategoryDto> ToDtoList(IEnumerable<ClientCategoryEntity> clientCategories)
    {
        return [.. clientCategories.Select(ToDto)];
    }
}
