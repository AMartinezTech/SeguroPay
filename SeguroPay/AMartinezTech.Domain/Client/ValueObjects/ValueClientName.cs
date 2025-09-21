

using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Client.ValueObjects;

public class ValueClientName 
{
    public string Value { get; init; }
    private ValueClientName(string value)
    {
        if (string.IsNullOrWhiteSpace(value.Trim()))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - nombre! ");

        if (value.Length > 15)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MaxLength)} (15) - nombre! ");

        if (value.Length < 4)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MinLength)} (4) - nombre! ");

        Value = value;
    }

    public static ValueClientName Create(string value)
    {
        return new ValueClientName(value);
    }

}
