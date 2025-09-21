using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.ValueObjects;


public class ValueDocIdentity
{
    public string Value { get; init; }

    private ValueDocIdentity(string value)
    {
        if (!IsValidRncOrCedula(value))
        {
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - identidad! ");
        }

        Value = value;
    }

    public static ValueDocIdentity Create(string value)
    {
        return new ValueDocIdentity(value);
    }

    private static bool IsValidRncOrCedula(string value)
    {
        return value.Length switch
        {
            9 => IsValidRnc(value),
            11 => IsValidCedula(value),
            _ => false
        };
    }

    private static bool IsValidRnc(string rnc)
    {
        return rnc.All(char.IsDigit);
    }

    private static bool IsValidCedula(string cedula)
    {
        if (cedula.Length != 11 || !cedula.All(char.IsDigit)) return false;

        // Algoritmo de validación de cédula (mod 10)
        int sum = 0;
        int[] weights = { 1, 2 }; // Alterna entre 1 y 2

        for (int i = 0; i < 10; i++)
        {
            int digit = cedula[i] - '0';
            int mult = digit * weights[i % 2];
            sum += mult >= 10 ? mult - 9 : mult;
        }

        int checkDigit = (10 - sum % 10) % 10;
        return checkDigit == cedula[10] - '0';
    }
}

