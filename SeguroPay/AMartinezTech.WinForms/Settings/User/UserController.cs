using AMartinezTech.Application.Setting.User;
using AMartinezTech.Application.Setting.User.UseCases.Read;
using AMartinezTech.Application.Setting.User.UseCases.Write;
using System.ComponentModel;

namespace AMartinezTech.WinForms.Settings.User;

public class UserController(UserPersistence persistence, UserGetById getById, UserFilter filter)
{
    private readonly UserPersistence _persistence = persistence;
    private readonly UserGetById _getById = getById;
    private readonly UserFilter _filter = filter;

    internal async Task<Guid> PersistenceAsync(UserDto dto)
    {
        return await _persistence.ExecuteAsync(dto);
    }
    internal async Task<UserDto> GetByIdAsync(Guid id)
    {
        return await _getById.ExecuteAsync(id);
    }
    internal async Task<BindingList<UserViewModel>> FilterAsync(string? filterStr = null, bool? isActived = null)
    {
        var result = await _filter.ExecuteAsync(filterStr, isActived);
        return new BindingList<UserViewModel>(UserViewModel.ToModelList(result));
    }
}
