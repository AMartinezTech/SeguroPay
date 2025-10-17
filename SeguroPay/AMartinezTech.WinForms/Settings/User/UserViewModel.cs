using AMartinezTech.Application.Setting.User;

namespace AMartinezTech.WinForms.Settings.User;

internal class UserViewModel
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string IsActiveName => IsActive ? "Activo" : "Inactivo"; 

    internal static UserViewModel ToModel(UserDto dto)
    {
        return new UserViewModel
        {
            Id = dto.Id,
            Email = dto.Email,
            FullName = dto.FullName,
            Phone = dto.Phone,
            Rol = dto.Rol,
            IsActive = dto.IsActive, 
        };
    }
    internal static List<UserViewModel> ToModelList(List<UserDto> list)
    {
        return [.. list.Select(ToModel).ToList()];
    }
}
