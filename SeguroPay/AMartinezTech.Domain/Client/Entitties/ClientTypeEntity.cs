

using AMartinezTech.Core.Interfaces;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Client.Entitties;

public class ClientTypeEntity : IAggregateRoot
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public bool IsActived { get; private set; }

    private ClientTypeEntity(Guid id, string name, bool isActived)
    {
        if (string.IsNullOrWhiteSpace(name.Trim()))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - Nombre! ");

        if (name.Length > 15)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MaxLength)} (15) - Nombre! ");

        if (name.Length < 4)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MinLength)} (4) - Nombre! ");

        Id = id;
        Name = name;
        IsActived = isActived;
    }

    public static ClientTypeEntity Create(Guid id, string name, bool isActived)
    {
        id = CreateGuid.EnsureId(id);
        return new ClientTypeEntity(id, name, isActived);
    }
}