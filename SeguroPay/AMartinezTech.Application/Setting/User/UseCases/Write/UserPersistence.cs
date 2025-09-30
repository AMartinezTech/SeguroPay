using AMartinezTech.Application.Setting.User.Interfaces;
using AMartinezTech.Domain.Setting.User;

namespace AMartinezTech.Application.Setting.User.UseCases.Write;

public class UserPersistence(IUserWriteRepository repository)
{
    private readonly IUserWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(UserDto dto)
    {
        var password = ValuePassword.Create(dto.Password, dto.ConfirmPassword);

        var entity = UserEntity.Create(dto.Id,dto.UserName,dto.CreatedAt,dto.Email, password, dto.FullName,dto.Phone,dto.Rol,dto.IsActived);

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }

        return entity.Id;
    }
}
