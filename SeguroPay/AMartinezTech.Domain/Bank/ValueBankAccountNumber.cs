using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Bank;

public class ValueBankAccountNumber
{
    public string Value { get; init; }

    private ValueBankAccountNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value.Trim()))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - número de cuenta! ");

        if (value.Length < 8 || value.Length > 25)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RangeValid)} 8 a 25 - número de cuenta! ");

        Value = value;
    }

    public static ValueBankAccountNumber Create(string value)
    {

        return new ValueBankAccountNumber(value);
    }
}
