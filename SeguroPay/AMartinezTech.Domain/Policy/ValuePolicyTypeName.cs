

using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Policy;

public class ValuePolicyTypeName
{
    public string Value { get; }

    private ValuePolicyTypeName(string value)
    {
        Value = value;
    }

    public static ValuePolicyTypeName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException($"{ErrorMessages.Get(ErrorType.RequiredField)} - nombre");

        if (value.Length < 6)
            throw new ValidationException($"{ErrorMessages.Get(ErrorType.MinLength)} - nombre");

        return new ValuePolicyTypeName(value);
    }
}
