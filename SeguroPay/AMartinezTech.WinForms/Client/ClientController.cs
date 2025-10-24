using AMartinezTech.Application.Client;
using AMartinezTech.Application.Location.City;
using AMartinezTech.Application.Location.City.UseCases.Read;
using AMartinezTech.Domain.Utils;
using System.ComponentModel;

namespace AMartinezTech.WinForms.Client;

public class ClientController(ClientAppServices service, CityPagination cityPagination)
{
    private readonly ClientAppServices _service = service;
    private readonly CityPagination _cityPagination = cityPagination;

    internal async Task<Guid> PersistenceAsync(ClientDto dto)
    {
        return await _service.PersistenceAsync(dto);
    }

    internal async Task<ClientDto> GetByIdAsync(Guid id)
    {
        return await _service.GetByIdAsync(id);
    }

    internal async Task<PageResult<ClientDto>> PaginationAsync(int pageNumber, int pageSize, bool? IsActive)
    {
        return await _service.PaginationAsync(pageNumber, pageSize, IsActive);
    }
    internal async Task<BindingList<ClientViewModel>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null )
    {
        var result = await _service.FilterAsync(filters,globalSearch);
        var modelList = result.Select(ClientViewModel.ToModel).ToList();
        return new BindingList<ClientViewModel>(modelList);
    }

    internal async Task<PageResult<CityDto>> CityPaginationAsync()
    {
        return await _cityPagination.ExecuteAsync(1,250,true);
    }
}
