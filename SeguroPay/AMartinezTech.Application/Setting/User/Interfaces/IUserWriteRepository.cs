using AMartinezTech.Domain.Setting.User;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Setting.User.Interfaces;

public interface IUserWriteRepository : ICreate<UserEntity>, IUpdate<UserEntity>;
