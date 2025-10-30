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
    public MemoryStream? Logo { get; private set; }
    private CompanyEntity(Guid id, DateTime createdAt, ValueCompanyName name, ValueDocIdentity rNC,  ValueEmail email, ValuePhone phone, ValueCompanyLine line1, ValueCompanyLine line2, bool isActive)
    {
        Id = id;
        CreatedAt = createdAt;
        Name = name;
        RNC = rNC;
        Email = email;
        Phone = phone;
        Line1 = line1;
        Line2 = line2;
        IsActive = isActive;
        
    }

    public static CompanyEntity Create(Guid id, DateTime createdAt, string name, string rNC,  string email, string phone, string line1, string line2, bool isActive, MemoryStream? logo)
    {
        id = CreateGuid.EnsureId(id);
        var entity = new CompanyEntity(id, createdAt, ValueCompanyName.Create(name), ValueDocIdentity.Create(rNC),  ValueEmail.Create(email), ValuePhone.Create(phone, "Phone"), ValueCompanyLine.Create(line1, "Line1"), ValueCompanyLine.Create(line2, "Line2"), isActive);
        entity.SetLogo(logo);
        return entity;
    }

    public void Update(string name, string rNC, string email, string phone, string line1, string line2, bool isActive, MemoryStream logo)
    {

        Name = ValueCompanyName.Create(name);
        RNC = ValueDocIdentity.Create(rNC);
        Email = ValueEmail.Create(email);
        Phone = ValuePhone.Create(phone, "Phone");
        Line1 = ValueCompanyLine.Create(line1, "Line1");
        Line2 = ValueCompanyLine.Create(line2, "Line2");
        IsActive = isActive;
        SetLogo(logo);

    }

    /// <summary>
    /// Asigna un nuevo logo asegurando que el stream sea seguro para uso interno.
    /// </summary>
    public void SetLogo(MemoryStream? logo)
    {
        if (logo == null)
        {
            Logo = null;
            return;
        }

        // Copia el contenido del stream a un nuevo MemoryStream
        var memory = new MemoryStream();
        logo.Position = 0; // aseguramos lectura desde el inicio
        logo.CopyTo(memory);
        memory.Position = 0;
        Logo = memory;
    }

    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}
