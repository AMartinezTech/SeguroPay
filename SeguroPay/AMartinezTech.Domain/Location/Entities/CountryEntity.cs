

using AMartinezTech.Core.Interfaces;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Location.Entities;

public class CountryEntity : IAggregateRoot
{

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private CountryEntity(Guid id, string name, DateTime createdAt)
    {


        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - nombre! ");

        Id = id;
        Name = name;

        CreatedAt = createdAt;
    }

    public static CountryEntity Create(Guid id, string name, DateTime createdAt)
    {
        id = CreateGuid.EnsureId(id);
        return new CountryEntity(id, name, createdAt);
    }
}
