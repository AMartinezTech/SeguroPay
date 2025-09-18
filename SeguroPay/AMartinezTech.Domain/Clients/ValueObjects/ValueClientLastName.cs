using AMartinezTech.Core.Enums;
using AMartinezTech.Core.ErrorExceptions;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Clients.ValueObjects;

public class ValueClientLastName
{
    public string Value { get; init; }

    private ValueClientLastName(string value)
    {
        if (string.IsNullOrWhiteSpace(value.Trim()))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - Apellidos! ");

        if (value.Length > 25)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MaxLength)} (25) - Apellidos! ");

        if (value.Length < 8)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MinLength)} (9) - Apellidos! ");


        Value = value;
    }

    public static ValueClientLastName Create(string value)
    {

        return new ValueClientLastName(value);
    }
}
