namespace AMartinezTech.Application.Bank;

public class BankAccountDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string Name { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? ContactName { get; set; }
    public string? ContactPhone { get; set; }
    public bool IsActive { get; set; }
    public string IsActiveName => IsActive ? "Si" : "No";
    public List<BankAccountMovementDto> Movements { get; set; } = [];
}
