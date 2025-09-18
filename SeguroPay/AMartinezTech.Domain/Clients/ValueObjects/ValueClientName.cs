using AMartinezTech.Core.Enums;
using AMartinezTech.Core.ErrorExceptions;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Clients.ValueObjects;

public class ValueClientName 
{
    public string Value { get; init; }
    private ValueClientName(string value)
    {
        if (string.IsNullOrWhiteSpace(value.Trim()))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - Nombre! ");

        if (value.Length > 15)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MaxLength)} (15) - Nombre! ");

        if (value.Length < 4)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MinLength)} (4) - Nombre! ");

        Value = value;
    }

    public static ValueClientName Create(string value)
    {
        return new ValueClientName(value);
    }

}
