using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils.ValueObjects;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Domain.Setting.User;

public class UserEntity : IAggregateRoot
{
    public Guid Id { get; private set; }
    public ValueUserName UserName { get; private set; }
    public ValueEmail Email { get; private set; }
    public ValuePassword Password { get; private set; }
    public ValueUserFullName FullName { get; private set; }
    public ValuePhone Phone { get; private set; }
    public ValueEnum<RolType> Rol { get; private set; }
    public bool IsActived { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private UserEntity(Guid id, ValueUserFullName fullName, ValueEmail email, ValuePhone phone, ValueUserName userName, ValuePassword password, ValueEnum<RolType> rol, bool isActived, DateTime createdAt)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        Phone = phone;
        UserName = userName;
        Password = password;
        Rol = rol;
        IsActived = isActived;
        CreatedAt = createdAt;
    }

    public static UserEntity Create(Guid id, string fullName, string email, string phone, string userName, ValuePassword password, string rol, bool isActived, DateTime createdAt)
    {
        id = CreateGuid.EnsureId(id);
        return new UserEntity(id, ValueUserFullName.Create(fullName), ValueEmail.Create(email), ValuePhone.Create(phone, "Phone"), ValueUserName.Create(userName), password, ValueEnum<RolType>.Create(rol), isActived, createdAt);
    }

}
