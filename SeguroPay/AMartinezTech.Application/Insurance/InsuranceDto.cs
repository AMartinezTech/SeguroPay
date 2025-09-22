namespace AMartinezTech.Application.Insurance;

public class InsuranceDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid CountryId { get; set; }
    public Guid RegionId { get; set; }
    public Guid CityId { get; set; } 
    public Guid StreetId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? ContactName { get; set; }
    public string? ContactPhone { get; set; }
    public bool IsActived { get; set; }
}
