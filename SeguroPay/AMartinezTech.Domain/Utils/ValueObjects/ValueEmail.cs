using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AMartinezTech.Domain.Utils.ValueObjects;

public class ValueEmail
{
    public string Value { get; init; }
    // Regex 
    private static readonly Regex ValidationRegex = new(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", RegexOptions.Compiled);

    // Private contructor
    private ValueEmail(string value)
    {

        if (string.IsNullOrEmpty(value))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - correo! ");

        if (!ValidationRegex.IsMatch(value))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.InvalidFormat)} - correo! ");
        Value = value;
    }

    // Method stactic for create the obj
    public static ValueEmail Create(string value)
    {
        return new ValueEmail(value);
    }
}
