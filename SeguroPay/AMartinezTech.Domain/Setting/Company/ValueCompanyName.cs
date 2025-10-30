

using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Setting.Company;

public class ValueCompanyName
{
    public string Value { get; init; }

    private ValueCompanyName(string value)
    {

        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - CompanyName! ");

        if (value.Length > 25)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MaxLength)} (25) - CompanyName! ");

        if (value.Length < 4)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MinLength)} (4) - CompanyName! ");
         
        Value = value;
        
    }

    public static ValueCompanyName Create(string value)
    {
        return new ValueCompanyName(value);
    }

}
