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

    private UserEntity(Guid id, ValueUserName userName, DateTime createdAt, ValueEmail email, ValuePassword password, ValueUserFullName fullName, ValuePhone phone, ValueEnum<RolType> rol, bool isActived)
    {
        Id = id;
        UserName = userName;
        CreatedAt = createdAt;
        Email = email;
        Password = password;
        FullName = fullName;
        Phone = phone;
        Rol = rol;
        IsActived = isActived;
    }

    public static UserEntity Create(Guid id, string userName, DateTime createdAt, string email, ValuePassword password, string fullName, string phone, string rol, bool isActived)
    {
        id = CreateGuid.EnsureId(id);
        return new UserEntity(id, ValueUserName.Create(userName), createdAt, ValueEmail.Create(email), password, ValueUserFullName.Create(fullName), ValuePhone.Create(phone, "Teléfono"), ValueEnum<RolType>.Create(rol), isActived);
    }

}
