﻿using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Cash.Expense;

public class ExpenseCategoryEntity : IAggregateRoot
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; }

    private ExpenseCategoryEntity(Guid id, string name, bool isActive)
    { 
        Id = id;
        Name = name;
        IsActive = isActive;
    }

    public static ExpenseCategoryEntity Create(Guid id, string name, bool isActive)
    {
        if (string.IsNullOrWhiteSpace(name.Trim()))
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - Nombre! ");

        if (name.Length > 15)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MaxLength)} (15) - Nombre! ");

        if (name.Length < 4)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.MinLength)} (4) - Nombre! ");

        id = CreateGuid.EnsureId(id);
        return new ExpenseCategoryEntity(id, name, isActive);
    }
}
