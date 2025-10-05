using AMartinezTech.Application.Setting.User.Interfaces;
using AMartinezTech.Domain.Setting.User;
using AMartinezTech.Domain.Utils.Exception;

namespace AMartinezTech.Application.Setting.User;

public class UserApplicationService(IUserWriteRepository writeRepository, IUserReadRepository readRepository, ICurrectUser userContext)
{
    private readonly IUserWriteRepository _writeRepository = writeRepository;
    private readonly IUserReadRepository _readRepository = readRepository;
    private readonly ICurrectUser _userContext = userContext;


    #region "Write"
    public async Task<Guid> PersistenceAsync(UserDto dto)
    {
        if (dto.Id == Guid.Empty)
        {
            return await CreateUserAsync(dto);
        }
        else
        {
            await UpdateUserAsync(dto);
            return dto.Id;
        }
    }
    private async Task<Guid> CreateUserAsync(UserDto dto)
    {
        var newUser = UserEntity.Create(
            dto.Id,
            dto.FullName,
            dto.Email,
            dto.Phone,
            dto.UserName,
            ValuePassword.Create(dto.Password, dto.ConfirmPassword),
            dto.Rol,
            dto.IsActived,
            DateTime.UtcNow);
        await _writeRepository.CreateAsync(newUser);
        return newUser.Id;
    }

    private async Task UpdateUserAsync(UserDto dto)
    {
        var user = await _readRepository.GetByIdAsync(dto.Id);
        user.Update(dto.Id, dto.FullName, dto.Phone, dto.Rol, dto.IsActived);
        await _writeRepository.UpdateAsync(user);
    }
    #endregion

    #region "Read"

    public async Task<List<UserDto>> FilterUsersAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? isActived = null)
    {
        var result = await _readRepository.FilterAsync(filters, globalSearch, isActived);
        return UserMapper.ToDtoList(result);
    }

    public async Task<UserDto> GetByIdUserAsync(Guid id)
    {
        var result = await _readRepository.GetByIdAsync(id);
        return UserMapper.ToDto(result);
    }
    public async Task<bool> LoginUserAsync(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username)) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - UserName");
        if (string.IsNullOrWhiteSpace(password)) throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - Password");
        var result = await _readRepository.LoginAsync(username, password);
        _userContext.SetUser(result);
        return true;
    }
    #endregion
}
