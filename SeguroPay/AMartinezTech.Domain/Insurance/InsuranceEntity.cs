using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Insurance;

public class InsuranceEntity : IAggregateRoot
{

    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ValueInsuranceName Name { get; private set; }
    public string? Address { get; private set; }
    public ValueEmail Email { get; private set; }
    public ValuePhone Phone { get; private set; }
    public string? ContactName { get; private set; }
    public string? ContactPhone { get; private set; }
    public bool IsActive { get; private set; }

    private InsuranceEntity(Guid id, DateTime createdAt, ValueInsuranceName name, string? address, ValueEmail email, ValuePhone phone, string? contactName, string? contactPhone, bool isActive )
    {
        Id = id;
        CreatedAt = createdAt;
        Name = name;
        Address = address;
        Email = email;
        Phone = phone;
        ContactName = contactName;
        ContactPhone = contactPhone;
        IsActive = isActive;
    }

    public static InsuranceEntity Create(Guid id, DateTime createdAt, string name, string? address, string email, string phone, string? contactName, string? contactPhone, bool isActive = true)
    {
        id = CreateGuid.EnsureId(id);
        return new InsuranceEntity(id, createdAt, ValueInsuranceName.Create(name), address, ValueEmail.Create(email), ValuePhone.Create(phone, nameof(Phone)), contactName, contactPhone, isActive);
    }

    public void Update(string name, string address, string email, string phone, string? contactName, string? contactPhone, bool isActive = true)
    {
        Name = ValueInsuranceName.Create(name);
        Address = address;
        Email = ValueEmail.Create(email);
        Phone = ValuePhone.Create(phone, nameof(Phone));
        ContactName = contactName;
        ContactPhone = contactPhone;
        IsActive = isActive;
    }
    public void MarkAsActivate() => IsActive = true;
    public void MarkAsInactivate() => IsActive = false;
}
