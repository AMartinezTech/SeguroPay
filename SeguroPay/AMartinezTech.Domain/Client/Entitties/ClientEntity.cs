using AMartinezTech.Domain.Client.ValueObjects;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils.ValueObjects;
namespace AMartinezTech.Domain.Client.Entitties;

public class ClientEntity : IAggregateRoot
{ 

    public Guid Id { get; private set; } 
    public ValueEnum<DocIdentityType> DocIdentityType { get; private set; }
    public ValueEnum<ClientType> ClientType { get; private set; }
    public string DocIdentity { get; private set; }
    public ValueClientName FirstName { get; private set; }
    public ValueClientLastName LastName { get; private set; } 
    public string Phone { get; private set; }
    public ValueEmail Email { get; private set; }
    public string? Observation { get; private set; }
    public string? LocationNo { get; private set; }
    public string? AddressRef { get; private set; }
    public string? ContactName {  get; private set; }
    public string? ContactPhone { get; private set; }
    public ValueGuid CityId { get; private set; }
    public ValueGuid StreetId { get; private set; }
    public bool IsActived { get; private set; }
    private ClientEntity(Guid id, ValueEnum<DocIdentityType> docIdentityType, ValueEnum<ClientType> clientType, string docIdentity, ValueClientName firstName, ValueClientLastName lastName,   string phone, ValueEmail email, string observation, string locationNo, string addressRef, bool isActived, string? contactName, string? contactPhone, ValueGuid cityId, ValueGuid streetId)
    {
        Id = id; 
        DocIdentityType = docIdentityType;
        ClientType = clientType;        
        DocIdentity = docIdentity;
        FirstName = firstName;
        LastName = lastName; 
        Phone = phone;
        Email = email;
        Observation = observation;
        LocationNo = locationNo;
        AddressRef = addressRef;
        IsActived = isActived;
        ContactName = contactName;
        ContactPhone = contactPhone;
        CityId = cityId;
        StreetId = streetId;
    }

    public static ClientEntity Create(Guid id,   string docIdentityType, string clientType, string docIdentity, string firstName, string lastName,   string phone, string email, string observation, string locationNo, string addressRef, bool isActived, string? contactName, string? contactPhone, Guid cityId, Guid streetId)
    {
       
        return new ClientEntity(CreateGuid.EnsureId(id), ValueEnum<DocIdentityType>.Create(docIdentityType), ValueEnum<ClientType>.Create(clientType), docIdentity, ValueClientName.Create(firstName), ValueClientLastName.Create(lastName), phone, ValueEmail.Create(email), observation, addressRef, locationNo, isActived, contactName, contactPhone, ValueGuid.Create(cityId,"City"), ValueGuid.Create(streetId,"Street"));
    }
    public void Activate() => IsActived = true;
    public void Deactivate() => IsActived = false;
}
