using AMartinezTech.Domain.Client.Entitties;

namespace AMartinezTech.Application.Client.Categories;

internal class ClientCategoryMapper
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
        return [.. clientCategories.Select(ToDto).ToList()];
    }
}
