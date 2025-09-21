using AMartinezTech.Core.Utils;

namespace AMartinezTech.Application.Client.Categories;

public class ClientCategoryQueries(IClientCategoryReadRepository repository)
{
    private readonly IClientCategoryReadRepository _repository = repository;

    public async Task<PagedResult<ClientCategoryDto>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = ClientCategoryMapper.ToDtoList(result.Data);
        return new PagedResult<ClientCategoryDto>(result.TotalRecords, pageSize, dtoList);
    }
}
