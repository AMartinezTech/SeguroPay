using AMartinezTech.Core.Enums;
using AMartinezTech.Core.ErrorExceptions;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Core.ValueObjects;

public class ValuePositiveNum
{
    public decimal Value { get; init; }
    private ValuePositiveNum(decimal value, string nameOfFeld)
    {
        if (value <= 0)
        {
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.NoNegativeNum)}  - {nameOfFeld}! ");
        }
        Value = value;
    }

    public static ValuePositiveNum Create(decimal value, string nameOfFeld)
    {
        return new ValuePositiveNum(value, nameOfFeld);
    }
}
