using AMartinezTech.Application.Location.Street;
using System.ComponentModel;

namespace AMartinezTech.WinForms.Location.Controllers;

public class StreetController(StreetApplicationService service)
{
    private readonly StreetApplicationService _service = service;

    public async Task<StreetDto> GetByIdAsync(Guid id)
    {
        return await _service.StreetGetByIdAsync(id);
    }
    public async Task<BindingList<StreetDto>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? isActived = null)
    {
        var result = await _service.FilterAsync(filters, globalSearch, isActived);
        return new BindingList<StreetDto>(result);
    }

    public async Task<Guid> PersistenceAsync(StreetDto dto)
    {
        return await _service.PersistenceAsync(dto);
    }
}
