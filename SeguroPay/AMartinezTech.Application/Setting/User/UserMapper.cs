using AMartinezTech.Domain.Setting.User;

namespace AMartinezTech.Application.Setting.User;

internal class UserMapper
{
    internal static UserDto ToDto(UserEntity entity)
    {
        return new UserDto
        {
            Id = entity.Id,
            UserName = entity.UserName!.Value,
            Email = entity.Email!.Value,
            FullName = entity.FullName.Value,
            Phone = entity.Phone.Value,
            Rol = entity.Rol.Type.ToString(),
            IsActived = entity.IsActived,
            CreatedAt = entity.CreatedAt!.Value
        };
    }

    internal static List<UserDto> ToDtoList(IEnumerable<UserEntity> entities) 
    {
        return [.. entities.Select(ToDto).ToList()];    
    }
}
