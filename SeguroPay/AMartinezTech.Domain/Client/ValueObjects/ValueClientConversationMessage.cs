

using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Client.ValueObjects;

public class ValueClientConversationMessage
{
    public string Value { get; }

    private ValueClientConversationMessage(string value)
    {
        Value = value;
    }

    public static ValueClientConversationMessage Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException($"{ErrorMessages.Get(ErrorType.RequiredField)} - Message");

        if (value.Length < 10)
            throw new ValidationException($"{ErrorMessages.Get(ErrorType.MinLength)} - Message");

        return new ValueClientConversationMessage(value);
    }
}
