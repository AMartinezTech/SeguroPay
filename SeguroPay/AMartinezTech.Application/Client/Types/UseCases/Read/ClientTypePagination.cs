using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Client.Types.UseCases.Read;

public class ClientTypePagination(IClientTypeReadRepository repository)
{
    private readonly IClientTypeReadRepository _repository = repository ;

    public async Task<PageResult<ClientTypeDto>> Pagination(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = ClientTypeMapper.ToDtoList(result.Data);

       return new PageResult<ClientTypeDto>(result.TotalRecords, pageSize, dtoList);
    }

}
