using AMartinezTech.Application.Clients.DTOs;
using AMartinezTech.Application.Clients.Repositories;
using AMartinezTech.Core.Utils;

namespace AMartinezTech.Application.Clients;

public class ClientQueries(IClientReadRepository repository)
{
    private readonly IClientReadRepository _repository = repository;

    public async Task<PagedResult<ClientDto>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = ClientMapper.ToDtoList(result.Data);

        return new PagedResult<ClientDto>(result.TotalRecords, pageSize, dtoList);
    }

    public async Task<IReadOnlyList<ClientDto>> FilterAsync(string? filter, bool? isActived)
    {
        var result = await _repository.FilterAsync(filter, isActived);
        return ClientMapper.ToDtoList(result);
    }

    public async Task<ClientDto> FilterAsync(Guid id)
    {
        var result = await _repository.GetById(id);
        return ClientMapper.ToDto(result);
    }
}
