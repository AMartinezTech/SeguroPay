

using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Client.ValueObjects;

public class ValueClientName 
{
    public string Value { get; init; }
    private ValueClientName(string value)
    {
        if (string.IsNullOrWhiteSpace(value.Trim()))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - FirstName! ");

        if (value.Length > 15)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MaxLength)} (15) - FirstName! ");

        if (value.Length < 2)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MinLength)} (2) - FirstName! ");

        Value = value;
    }

    public static ValueClientName Create(string value)
    {
        return new ValueClientName(value);
    }

}
