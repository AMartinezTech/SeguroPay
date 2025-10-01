using AMartinezTech.Application.Setting.User.Interfaces;
using AMartinezTech.Domain.Setting.User;

namespace AMartinezTech.Application.Setting.User.UseCases.Write;

public class UserPersistence(IUserWriteRepository repository)
{
    private readonly IUserWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(UserDto dto)
    { 
        var entity = UserEntity.Create(
            dto.Id,
            dto.FullName,
            dto.Email, 
            dto.Phone,
            dto.UserName,
            ValuePassword.Create(dto.Password, dto.ConfirmPassword), 
            dto.Rol,
            dto.IsActived,
            dto.CreatedAt
            );

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }

        return entity.Id;
    }
}
