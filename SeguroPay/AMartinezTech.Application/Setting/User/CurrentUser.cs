using AMartinezTech.Application.Setting.User.Interfaces;
using AMartinezTech.Domain.Setting.User;

namespace AMartinezTech.Application.Setting.User;

public class CurrentUser : ICurrectUser
{
    public UserEntity? User { get; private set; }

    public bool IsLoggedIn => User != null;

    public void Clear()
    {
        User = null;
    }

    public void SetUser(UserEntity user)
    {
        User = user;
    }
}
