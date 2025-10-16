using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AMartinezTech.Domain.Utils.ValueObjects;

public class ValuePhone
{
    public string Value { get; init; }


    private ValuePhone(string value, string nameOfFeld)
    {
        var regexRD = new Regex(@"^(809|829|849)-\d{3}-\d{4}$");
         
        if (!string.IsNullOrEmpty(value))
        {
            if (!regexRD.IsMatch(value))
                throw new ValidationException($" {ErrorMessages.Get(ErrorType.InvalidFormat)}  - {nameOfFeld} ");
        }

        Value = value;
    }

    public static ValuePhone Create(string value, string nameOfFeld)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException($"{ErrorMessages.Get(ErrorType.RequiredField)} - {nameOfFeld}");

        return new ValuePhone(value, nameOfFeld);
    }
}
