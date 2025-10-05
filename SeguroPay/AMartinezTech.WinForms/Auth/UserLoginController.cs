using AMartinezTech.Application.Setting.User;

namespace AMartinezTech.WinForms.Auth;

public class UserLoginController(UserApplicationService service)
{
    private readonly UserApplicationService _service = service;
    public async Task<bool> LoginUserAsync(string username, string password)
    {
        return await _service.LoginUserAsync(username, password);
    }

}
