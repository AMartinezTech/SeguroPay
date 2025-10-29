using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Setting.Company;

public class CompanyEntity : IAggregateRoot
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ValueDocIdentity RNC { get; private set; }
    public ValueCompanyName Name { get; private set; }
    public ValueEmail Email { get; private set; }
    public ValuePhone Phone { get; private set; }
    public ValueCompanyLine Line1 { get; private set; }
    public ValueCompanyLine Line2 { get; private set; }
    public bool IsActive { get; private set; }
    public MemoryStream Logo { get; private set; }
    private CompanyEntity(Guid id, DateTime createdAt, ValueDocIdentity rNC, ValueCompanyName name, ValueEmail email, ValuePhone phone, ValueCompanyLine line1, ValueCompanyLine line2, bool isActive, MemoryStream logo)
    {
        Id = id;
        CreatedAt = createdAt;
        RNC = rNC;
        Name = name;
        Email = email;
        Phone = phone;
        Line1 = line1;
        Line2 = line2;
        IsActive = isActive;
        Logo = logo;
    }

    public static CompanyEntity Create(Guid id, DateTime createdAt, string rNC, string name, string email, string phone, string line1, string line2, bool isActive, MemoryStream logo)
    {
        id = CreateGuid.EnsureId(id);
        return new CompanyEntity(id, createdAt, ValueDocIdentity.Create(rNC), ValueCompanyName.Create(name), ValueEmail.Create(email), ValuePhone.Create(phone, "Teléfono"), ValueCompanyLine.Create(line1, "Linea 1"), ValueCompanyLine.Create(line2, "Linea 2"), isActive, logo);

    }
    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}
