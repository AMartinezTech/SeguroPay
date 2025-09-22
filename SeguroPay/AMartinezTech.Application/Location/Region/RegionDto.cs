namespace AMartinezTech.Application.Location.Region;

public class RegionDto
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
