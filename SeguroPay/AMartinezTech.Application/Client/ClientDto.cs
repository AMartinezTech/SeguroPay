namespace AMartinezTech.Application.Client;

public class ClientDto
{
    public Guid Id { get; set; } 
    public string DocIdentityType { get; set; } = string.Empty;
    public string ClientType { get; set; } = string.Empty;
    public string DocIdentity { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Guid StreetId { get; set; }
    public Guid CityId { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Observation { get; set; }
    public string? LocationNo { get; set; }
    public string? AddressRef { get; set; }
    public string? ContactName { get; set; }
    public string? ContactPhone { get; set; }
    public bool IsActived { get; set; }
}
