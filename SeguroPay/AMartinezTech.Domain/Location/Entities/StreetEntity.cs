

using AMartinezTech.Core.Interfaces;
using AMartinezTech.Domain.Utils.ValueObjects;
using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Domain.Location.Entities;

public class StreetEntity : IAggregateRoot
{
    public Guid Id { get; private set; }
    public ValueGuid CityId { get; private set; }
    public string Name { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private StreetEntity(Guid id, ValueGuid cityId, string name, DateTime createdAt)
    { 
        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - nombre! ");


        Id = id;
        CityId = cityId;
        Name = name;
        CreatedAt = createdAt;
    }

    public static StreetEntity Create(Guid id, Guid cityId, string name, DateTime createdAt)
    {
        id = CreateGuid.EnsureId(id);
        return new StreetEntity(id, ValueGuid.Create(cityId,"ciudad"), name, createdAt);

    }
}
