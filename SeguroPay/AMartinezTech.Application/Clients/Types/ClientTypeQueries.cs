using AMartinezTech.Core.Utils;

namespace AMartinezTech.Application.Clients.Types;

public class ClientTypeQueries(IClientTypeReadRepository repository)
{
    private readonly IClientTypeReadRepository _repository = repository ;

    public async Task<PagedResult<ClientTypeDto>> Pagination(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = ClientTypeMapper.ToDtoList(result.Data);

       return new PagedResult<ClientTypeDto>(result.TotalRecords, pageSize, dtoList);
    }

}
