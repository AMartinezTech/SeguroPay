

using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Policy;

public class ValuePolicyPayDay
{
    public int Value { get; }

    private ValuePolicyPayDay(int value)
    {
        Value = value;
    }

    public static ValuePolicyPayDay Create(int value, int minRange = 1, int maxRange = 30)
    {
        if (value < 1 || value > 30)
            throw new ValidationException($"{ErrorMessages.Get(ErrorType.RangeValid)} {minRange} a {maxRange} - PayDay");
          
        return new ValuePolicyPayDay(value);
    }
}
