using AMartinezTech.Domain.Utils.Exception;

namespace AMartinezTech.Domain.Setting.User;

public class ValueUserName
{
    public string Value { get; init; }

    private ValueUserName(string value)
    {
        Value = value;
    }

    public static ValueUserName Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - UserName");

        if (value.Length < 4)
            throw new Exception($"{ErrorMessages.Get(ErrorType.MinLength)} 4 - UserName");

        if (value.Length > 50)
            throw new Exception($"{ErrorMessages.Get(ErrorType.MinLength)} 50 - UserName");

        return new ValueUserName(value);
    }
}