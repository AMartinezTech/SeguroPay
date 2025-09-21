

using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Insurance;

public class ValueInsuranceName
{
    public string Value { get; init; }

    private ValueInsuranceName(string value)
    {

        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - nombre! ");

        if (value.Length > 50)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MaxLength)} (50) - nombre! ");

        if (value.Length < 6)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MinLength)} (6) - nombre! ");

        Value = value;

    }

    public static ValueInsuranceName Create(string value)
    {
        return new ValueInsuranceName(value);
    }

}
