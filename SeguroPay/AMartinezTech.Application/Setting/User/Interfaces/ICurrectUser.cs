using AMartinezTech.Domain.Setting.User;

namespace AMartinezTech.Application.Setting.User.Interfaces;

public interface ICurrectUser
{
    UserEntity? User { get; }
    void SetUser(UserEntity user);
    void Clear();
    bool IsLoggedIn { get; }
}
