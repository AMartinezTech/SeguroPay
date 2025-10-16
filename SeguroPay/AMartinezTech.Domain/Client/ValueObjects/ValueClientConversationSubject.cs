

using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Client.ValueObjects;

public class ValueClientConversationSubject
{
    public string Value { get; }

    private ValueClientConversationSubject(string value)
    {
        Value = value;
    }

    public static ValueClientConversationSubject Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException($"{ErrorMessages.Get(ErrorType.RequiredField)} - Subject");

        if (value.Length < 10)
            throw new ValidationException($"{ErrorMessages.Get(ErrorType.MinLength)} - Subject");

        return new ValueClientConversationSubject(value);
    }
}
