﻿using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.ValueObjects;

public class ValueGuid
{
    public Guid Value { get; }

    private ValueGuid(Guid value)
    {
        Value = value;
    }

    public static ValueGuid Create(Guid value, string name)
    {
        if (value == Guid.Empty)
            throw new ValidationException($"{ErrorMessages.Get(ErrorType.InvalidType)} - {name}");


        return new ValueGuid(value);
    }
}
