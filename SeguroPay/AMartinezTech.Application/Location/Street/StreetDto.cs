namespace AMartinezTech.Application.Location.Street;

public class StreetDto
{
    public Guid Id { get; set; }
    public Guid CityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } 
}
