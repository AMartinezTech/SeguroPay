
using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils.ValueObjects;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Domain.Setting.User;

public class UserEntity : IAggregateRoot
{

    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ValueEmail Email { get; private set; }
    public ValueUserPassword Password { get; private set; }
    public ValueUserFullName FullName { get; private set; }
    public ValuePhone Phone { get; private set; }
    public ValueEnum<RolType> Rol { get; private set; }
    public bool IsActived { get; private set; }

    private UserEntity(Guid id, DateTime createdAt, ValueEmail email, ValueUserPassword password, ValueUserFullName fullName, ValuePhone phone, ValueEnum<RolType> rol, bool isActived)
    {
        Id = id;
        CreatedAt = createdAt;
        Email = email;
        Password = password;
        FullName = fullName;
        Phone = phone;
        Rol = rol;
        IsActived = isActived;
    }

    public static UserEntity Create(Guid id, DateTime createdAt, string email, string password, string fullName, string phone, string rol, bool isActived)
    {
        id = CreateGuid.EnsureId(id);
        return new UserEntity(id, createdAt, ValueEmail.Create(email), ValueUserPassword.Create(password), ValueUserFullName.Create(fullName), ValuePhone.Create(phone, "Teléfono"), ValueEnum<RolType>.Create(rol), isActived);
    }
    public void Activate() => IsActived = true;
    public void Deactivate() => IsActived = false;
}
