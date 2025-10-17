using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils.ValueObjects;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Domain.Setting.User;

public class UserEntity : IAggregateRoot
{
    public Guid Id { get; private set; }
    public ValueUserName? UserName { get; private set; }
    public ValueEmail? Email { get; private set; }
    public ValuePassword? Password { get; private set; }
    public ValueUserFullName FullName { get; private set; }
    public ValuePhone Phone { get; private set; }
    public ValueEnum<RolType> Rol { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime? CreatedAt { get; private set; }

    private UserEntity(Guid id, ValueUserFullName fullName, ValueEmail? email, ValuePhone phone, ValueUserName? userName, ValuePassword? password, ValueEnum<RolType> rol, bool isActive, DateTime? createdAt)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        Phone = phone;
        UserName = userName;
        Password = password;
        Rol = rol;
        IsActive = isActive;
        CreatedAt = createdAt;
    }

    public void Update(Guid id, string fullName, string phone, string rol, bool isActive)
    {
        Id = id;
        FullName = ValueUserFullName.Create(fullName);
        Phone = ValuePhone.Create(phone, "Phone");
        Rol = ValueEnum<RolType>.Create(rol);
        IsActive = isActive;
        CreatedAt = DateTime.UtcNow;
    }

    public static UserEntity Create(Guid id, string fullName, string email, string phone, string userName, ValuePassword password, string rol, bool IsActive, DateTime? createdAt)
        => new(CreateGuid.EnsureId(id),
            ValueUserFullName.Create(fullName),
            ValueEmail.Create(email),
            ValuePhone.Create(phone, "Phone"),
            ValueUserName.Create(userName),
            password,
            ValueEnum<RolType>.Create(rol),
            IsActive,
            createdAt);

    
    public static UserEntity LoadExisting(Guid id, string fullName, string email, string phone, string userName, string rol, bool IsActive, DateTime createdAt)
        => new(id,
            ValueUserFullName.Create(fullName),
            ValueEmail.Create(email),
            ValuePhone.Create(phone, "Phone"),
            ValueUserName.Create(userName),
            null,
            ValueEnum<RolType>.Create(rol),
            IsActive,
            createdAt);

}
