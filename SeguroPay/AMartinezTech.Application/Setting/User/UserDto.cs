namespace AMartinezTech.Application.Setting.User;

public class UserDto
{
    public Guid Id { get;  set; }
    public string UserName { get;  set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
    public bool IsActived { get;  set; }
    public DateTime CreatedAt { get;  set; }
}
