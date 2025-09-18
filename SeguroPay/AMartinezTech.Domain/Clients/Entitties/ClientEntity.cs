using AMartinezTech.Core.Interfaces;
using AMartinezTech.Core.Utils;
using AMartinezTech.Core.ValueObjects;
using AMartinezTech.Domain.Clients.ValueObjects;
namespace AMartinezTech.Domain.Clients.Entitties;

public class ClientEntity : IAggregateRoot
{

    public Guid Id { get; private set; }
    public Guid CategoryId { get; private set; }
    public Guid DocIdentityTypeId { get; private set; }
    public Guid TypeId { get; private set; }
    public ValueDocIdentity DocIdentity { get; private set; }
    public ValueClientName FirstName { get; private set; }
    public ValueClientLastName LastName { get; private set; }
    public Guid StreetId { get; private set; }
    public Guid CityId { get; private set; }
    public Guid RegionId { get; private set; }
    public Guid PostalCodeId { get; private set; }
    public Guid CountryId { get; private set; }
    public ValuePhone Phone { get; private set; }
    public ValueEmail Email { get; private set; }
    public string? Observation { get; private set; }
    public string? LocationNo { get; private set; }
    public string? AddressRef { get; private set; }
    public bool IsActived { get; private set; }
    private ClientEntity(Guid id, Guid categoryId, Guid docIdentityTypeId, Guid typeId, ValueDocIdentity docIdentity, ValueClientName firstName, ValueClientLastName lastName, Guid streetId, Guid cityId, Guid regionId, Guid postalCodeId, Guid countryId, ValuePhone phone, ValueEmail email, string observation, string locationNo, string addressRef, bool isActived)
    {
        Id = id;
        CategoryId = categoryId;
        DocIdentityTypeId = docIdentityTypeId;
        TypeId = typeId;
        DocIdentity = docIdentity;
        FirstName = firstName;
        LastName = lastName;
        StreetId = streetId;
        CityId = cityId;
        RegionId = regionId;
        PostalCodeId = postalCodeId;
        CountryId = countryId;
        Phone = phone;
        Email = email;
        Observation = observation;
        LocationNo = locationNo;
        AddressRef = addressRef;
        IsActived = isActived;
    }

    public static ClientEntity Create(Guid id, Guid categoryId, Guid docIdentityTypeId, Guid typeId, string docIdentity, string firstName, string lastName, Guid streetId, Guid cityId, Guid regionId, Guid postalCodeId, Guid countryId, string phone, string email, string observation, string locationNo, string addressRef, bool isActived)
    {
        id = CreateGuid.EnsureId(id);
        return new ClientEntity(id, categoryId, docIdentityTypeId, typeId, ValueDocIdentity.Create(docIdentity), ValueClientName.Create(firstName), ValueClientLastName.Create(lastName), streetId, cityId, regionId, postalCodeId, countryId, ValuePhone.Create(phone, "Teléfono"), ValueEmail.Create(email), observation, addressRef, locationNo, isActived);
    }

}
