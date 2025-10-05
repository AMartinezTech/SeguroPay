using AMartinezTech.Application.Client;
using AMartinezTech.Domain.Utils;
using System.ComponentModel;

namespace AMartinezTech.WinForms.Client;

public class ClientController(ClientApplicationService service)
{
    private readonly ClientApplicationService _service = service;

    internal async Task<Guid> PersistenceAsync(ClientDto dto)
    {
        return await _service.PersistenceAsync(dto);
    }

    internal async Task<ClientDto> GetByIdAsync(Guid id)
    {
        return await _service.GetByIdAsync(id);
    }

    internal async Task<PageResult<ClientDto>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        return await _service.PaginationAsync(pageNumber, pageSize, isActived);
    }
    internal async Task<BindingList<ClientViewModel>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? isActived = null)
    {
        var result = await _service.FilterAsync(filters,globalSearch,isActived);
        var modelList = result.Select(ClientViewModel.ToModel).ToList();
        return new BindingList<ClientViewModel>(modelList);
    }
}
