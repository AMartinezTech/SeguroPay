

using AMartinezTech.Domain.Utils.Interfaces; 
using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Domain.Location.Entities;

public class StreetEntity : IAggregateRoot
{
    public Guid Id { get; private set; }
    public Guid CityId { get; private set; }
    public string StreetName { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private StreetEntity(Guid id, Guid cityId, string streetName, DateTime createdAt)
    { 
        if (string.IsNullOrWhiteSpace(streetName))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - StreetName ");

        if (streetName.Length < 8)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MinLength)} - StreetName ");

        if (cityId == Guid.Empty)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - City ");



        Id = id;
        CityId = cityId;
        StreetName = streetName;
        CreatedAt = createdAt;
    }

    public static StreetEntity Create(Guid id, Guid cityId, string name, DateTime createdAt)
    {
        id = CreateGuid.EnsureId(id);
        return new StreetEntity(id, cityId, name, createdAt);

    }
}
