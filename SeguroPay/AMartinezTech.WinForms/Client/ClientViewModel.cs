using AMartinezTech.Application.Client;

namespace AMartinezTech.WinForms.Client;

internal class ClientViewModel
{
    public Guid Id { get; set; }
    public string ClientType { get; set; } = string.Empty;
    public string DocIdentity { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? ContactName { get; set; }
    public string? ContactPhone { get; set; }
    public bool IsActived { get; set; }
    public string FullName => FirstName +" "+ LastName;
    public string IsActivedName => IsActived ? "Activo" : "Inactivo";

    internal static ClientViewModel ToModel(ClientDto dto)
    {
        return new ClientViewModel
        {
            Id = dto.Id,
            ClientType = dto.ClientType,
            DocIdentity = dto.DocIdentity,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Phone = dto.Phone,
            Email = dto.Email,
            ContactName = dto.ContactName,
            ContactPhone = dto.ContactPhone,
            IsActived = dto.IsActived,

        };
    }
     
}
