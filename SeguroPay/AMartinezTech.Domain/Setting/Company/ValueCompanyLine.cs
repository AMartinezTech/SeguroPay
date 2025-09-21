

using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Setting.Company;

public class ValueCompanyLine
{
    public string Value { get; init; }

    private ValueCompanyLine(string value, string lineName)
    {
        if (value.Length > 300)
            throw new ValidationException($"{ErrorMessages.Get(ErrorType.MaxLength)} - {lineName}!");

        Value = value;
    }

    public static ValueCompanyLine Create(string value, string lineName)
    {
        return new ValueCompanyLine(value, lineName);
    }

}
