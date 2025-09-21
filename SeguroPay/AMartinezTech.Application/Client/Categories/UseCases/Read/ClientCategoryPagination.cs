using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Client.Categories.UseCases.Read;

public class ClientCategoryPagination(IClientCategoryReadRepository repository)
{
    private readonly IClientCategoryReadRepository _repository = repository;

    public async Task<PageResult<ClientCategoryDto>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = ClientCategoryMapper.ToDtoList(result.Data);
        return new PageResult<ClientCategoryDto>(result.TotalRecords, pageSize, dtoList);
    }
}
