using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Bank;

public class ValueBankAccountName
{
    public string Value { get; init; }

    private ValueBankAccountName(string value)
    {
        if (string.IsNullOrWhiteSpace(value.Trim()))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - Name ");

        if (value.Length < 8 || value.Length > 25)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RangeValid)} 8 a 25 - Name ");

        Value = value;
    }

    public static ValueBankAccountName Create(string value)
    {

        return new ValueBankAccountName(value);
    }
} 