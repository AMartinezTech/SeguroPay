

using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Client.ValueObjects;

public class ValueClientLastName
{
    public string Value { get; init; }

    private ValueClientLastName(string value)
    {
        if (string.IsNullOrWhiteSpace(value.Trim()))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - Lastname");

        if (value.Length < 3 || value.Length > 20)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RangeValid)} 3 a 20 - LastName");

        Value = value;
    }

    public static ValueClientLastName Create(string value)
    {

        return new ValueClientLastName(value);
    }
}
