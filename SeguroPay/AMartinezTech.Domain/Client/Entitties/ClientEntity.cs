using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils.ValueObjects;
using AMartinezTech.Domain.Client.ValueObjects;
using AMartinezTech.Domain.Utils;
namespace AMartinezTech.Domain.Client.Entitties;

public class ClientEntity : IAggregateRoot
{ 

    public Guid Id { get; private set; }
    public ValueGuid CategoryId { get; private set; }
    public ValueGuid DocIdentityTypeId { get; private set; }
    public ValueGuid TypeId { get; private set; }
    public ValueDocIdentity DocIdentity { get; private set; }
    public ValueClientName FirstName { get; private set; }
    public ValueClientLastName LastName { get; private set; }
    public ValueAddress Address { get; private set; }
    public ValuePhone Phone { get; private set; }
    public ValueEmail Email { get; private set; }
    public string? Observation { get; private set; }
    public string? LocationNo { get; private set; }
    public string? AddressRef { get; private set; }
    public string? ContactName {  get; private set; }
    public string? ContactPhone { get; private set; }
    public bool IsActived { get; private set; }
    private ClientEntity(Guid id, ValueGuid categoryId, ValueGuid docIdentityTypeId, ValueGuid typeId, ValueDocIdentity docIdentity, ValueClientName firstName, ValueClientLastName lastName, ValueAddress address, ValuePhone phone, ValueEmail email, string observation, string locationNo, string addressRef, bool isActived, string? contactName, string? contactPhone)
    {
        Id = id;
        CategoryId = categoryId;
        DocIdentityTypeId = docIdentityTypeId;
        TypeId = typeId;
        DocIdentity = docIdentity;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Phone = phone;
        Email = email;
        Observation = observation;
        LocationNo = locationNo;
        AddressRef = addressRef;
        IsActived = isActived;
        ContactName = contactName;
        ContactPhone = contactPhone;
    }

    public static ClientEntity Create(Guid id, Guid categoryId, Guid docIdentityTypeId, Guid typeId, string docIdentity, string firstName, string lastName, ValueAddress address, string phone, string email, string observation, string locationNo, string addressRef, bool isActived, string? contactName, string? contactPhone)
    {
        id = CreateGuid.EnsureId(id);
        return new ClientEntity(id, ValueGuid.Create(categoryId,"categoría"), ValueGuid.Create(docIdentityTypeId,"tipo doc. identidad"), ValueGuid.Create(typeId, "tipo"), ValueDocIdentity.Create(docIdentity), ValueClientName.Create(firstName), ValueClientLastName.Create(lastName),address, ValuePhone.Create(phone, "Teléfono"), ValueEmail.Create(email), observation, addressRef, locationNo, isActived, contactName, contactPhone);
    }
    public void Activate() => IsActived = true;
    public void Deactivate() => IsActived = false;
}
