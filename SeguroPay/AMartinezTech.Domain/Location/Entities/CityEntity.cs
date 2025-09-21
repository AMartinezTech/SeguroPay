

using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Location.Entities;

public class CityEntity : IAggregateRoot
{

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid RegionId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private CityEntity(Guid id, string name, Guid regionId, DateTime createdAt)
    {
        if (regionId == Guid.Empty)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - provincia! ");

        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - nombre! ");

        Id = id;
        Name = name;
        RegionId = regionId;
        CreatedAt = createdAt;
    }

    public static CityEntity Create(Guid id, string name, Guid regionId, DateTime createdAt)
    {
        id = CreateGuid.EnsureId(id);
        return new CityEntity(id, name, regionId, createdAt);
    }
}
