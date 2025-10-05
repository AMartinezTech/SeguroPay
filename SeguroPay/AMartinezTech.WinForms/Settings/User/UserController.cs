using AMartinezTech.Application.Setting.User;
using System.ComponentModel;

namespace AMartinezTech.WinForms.Settings.User;

public class UserController(UserApplicationService service)
{
    private readonly UserApplicationService _service = service;

    internal async Task<Guid> PersistenceAsync(UserDto dto)
    {
        return await _service.PersistenceAsync(dto);
    }
    internal async Task<UserDto> GetByIdAsync(Guid id)
    {
        return await _service.GetByIdUserAsync(id);
    }
    internal async Task<BindingList<UserViewModel>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? isActived = null)
    {
        var result = await _service.FilterUsersAsync(filters, globalSearch, isActived);
        return new BindingList<UserViewModel>(UserViewModel.ToModelList(result));
    }
}
