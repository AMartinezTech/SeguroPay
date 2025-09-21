

using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AMartinezTech.Domain.Setting.User;

public class ValueUserPassword 
{
    public string Value { get; }

    private ValueUserPassword(string value)
    {
        Value = value;
    }

    public static ValueUserPassword Create(string value, int minLength = 6, int maxLength = 12)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException($"{ErrorMessages.Get(ErrorType.RequiredField)} - clave");

        if (value.Length < minLength || value.Length > maxLength)
            throw new ValidationException($"La clave debe tener entre {minLength} y {maxLength} caracteres.");

        // Validación: al menos una letra y un número
        var regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d).+$");
        if (!regex.IsMatch(value))
            throw new ArgumentException("La clave debe contener al menos una letra y un número.");

        return new ValueUserPassword(value);
    }
    
    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => Value;
}
