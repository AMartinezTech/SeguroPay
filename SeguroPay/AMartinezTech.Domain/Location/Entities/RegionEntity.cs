

using AMartinezTech.Core.Interfaces;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Location.Entities;

public class RegionEntity : IAggregateRoot
{
    public Guid Id { get; private set; }
    public Guid CountryId { get; private set; }
    public string Name { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private RegionEntity(Guid id, Guid countryId, string name, DateTime createdAt)
    {

        if (countryId == Guid.Empty)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - país! ");

        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - nombre! ");

        Id = id;
        CountryId = countryId;
        Name = name;
        CreatedAt = createdAt;
    }

    public static RegionEntity Create(Guid id, Guid countryId, string name, DateTime createdAt)
    {
        id = CreateGuid.EnsureId(id);
        return new RegionEntity(id, countryId, name, createdAt);
    }
}
