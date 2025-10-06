namespace AMartinezTech.Application.Location.City;

public class CityDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid RegionId { get; set; }
    public DateTime CreatedAt { get; set; }
}
