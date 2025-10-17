namespace AMartinezTech.Application.Utils;

public abstract class BaseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

