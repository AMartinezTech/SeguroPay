namespace AMartinezTech.Application.Policy.Type;

public class PolicyTypeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public Guid InsuranceId { get; set; }

    public string IsActiveName => IsActive ? "Activo" : "Inactivo";
}
