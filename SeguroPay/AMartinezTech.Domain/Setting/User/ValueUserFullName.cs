

using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Setting.User;

public class ValueUserFullName
{
    public string Value { get; init; }

    private ValueUserFullName(string value)
    {
        Value = value;
    }

    public static ValueUserFullName Create(string value, int minLength = 6)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException($"{ErrorMessages.Get(ErrorType.RequiredField)} - FullName");

        if (value.Length < minLength )
            throw new ValidationException($"{ErrorMessages.Get(ErrorType.MinLength)} - FullName");
        return new ValueUserFullName(value);
    }
}
