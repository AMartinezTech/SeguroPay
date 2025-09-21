

using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Client.ValueObjects;

public class ValueClientLastName
{
    public string Value { get; init; }

    private ValueClientLastName(string value)
    {
        if (string.IsNullOrWhiteSpace(value.Trim()))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - apellidos! ");

        if (value.Length < 8 || value.Length > 50)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RangeValid)} 8 a 50 - apellidos! ");

        Value = value;
    }

    public static ValueClientLastName Create(string value)
    {

        return new ValueClientLastName(value);
    }
}
