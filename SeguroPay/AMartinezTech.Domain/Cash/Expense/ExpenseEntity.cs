using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exception;
using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Cash.Expense;

public class ExpenseEntity : IAggregateRoot
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ValueGuid CategoryId { get; private set; }
    public string? CategoryName { get; private set; }
    public ValuePositiveNum Amount { get; private set; }
    public string? Note { get; private set; }
    public bool IsActive { get; private set; }
    public Guid CreatedBy { get; private set; }

    private ExpenseEntity(Guid id, DateTime createdAt, ValueGuid categoryId, ValuePositiveNum amount, string? note, bool isActive, Guid createdBy)
    {
        Id = id;
        CreatedAt = createdAt;
        CategoryId = categoryId;
        Amount = amount;
        Note = note;
        IsActive = isActive;
        CreatedBy = createdBy;
    }

    public static ExpenseEntity Create(Guid id, DateTime createdAt, Guid categoryId, decimal amount, string? note, bool isActive, Guid createdBy)
    {

        if(createdBy == Guid.Empty)
            throw new ValidationException($" {ErrorMessages.Get(ErrorType.InvalidUser)} - CreatedBy ");

        id = CreateGuid.EnsureId(id);
        return new ExpenseEntity(id, createdAt, ValueGuid.Create(categoryId, "Category"), ValuePositiveNum.Create(amount, "Amount"), note, isActive, createdBy);
    }

    public void SetCategoryName(string name)
    {
        CategoryName = name;
    }
}
