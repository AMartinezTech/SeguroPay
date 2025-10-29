namespace AMartinezTech.Application.Setting.Company;

public class CompanyDto
{
    public Guid Id { get;  set; }
    public DateTime CreatedAt { get;  set; }
    public string RNC { get;  set; } = string.Empty;
    public string Name { get;  set; } = string.Empty;
    public string Email { get;  set; } = string.Empty;
    public string Phone { get;  set; } = string.Empty;
    public string Line1 { get;  set; } = string.Empty;
    public string Line2 { get;  set; } = string.Empty;
    public bool IsActive { get;  set; }
    public MemoryStream Logo { get;  set; }
}
