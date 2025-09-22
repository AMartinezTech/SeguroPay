using AMartinezTech.Application.Client.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Client.UseCases.Read;

public class ClientPagination(IClientReadRepository repository)
{
    private readonly IClientReadRepository _repository = repository;
    public async Task<PageResult<ClientDto>> ExecuteAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = ClientMapper.ToDtoList(result.Data);

        return new PageResult<ClientDto>(result.TotalRecords, pageSize, dtoList);
    }
}
