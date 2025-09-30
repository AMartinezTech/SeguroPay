using AMartinezTech.Domain.Setting.User;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Setting.User.Interfaces;

public interface IUserReadRepository : IFilter<UserEntity>, IGetById<UserEntity, Guid>
{
    Task<UserEntity> LoginAsync(string userName, string password);

}
