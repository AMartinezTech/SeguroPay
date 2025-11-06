using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.ValueObjects;

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

    private ExpenseEntity(Guid id, DateTime createdAt, ValueGuid categoryId, ValuePositiveNum amount, string? note, bool isActive)
    {
        Id = id;
        CreatedAt = createdAt;
        CategoryId = categoryId;
        Amount = amount;
        Note = note;
        IsActive = isActive;
    }

    public static ExpenseEntity Create(Guid id, DateTime createdAt, Guid categoryId, decimal amount, string? note, bool isActive)
    {
        id = CreateGuid.EnsureId(id);
        return new ExpenseEntity(id, createdAt, ValueGuid.Create(categoryId, "Category"), ValuePositiveNum.Create(amount, "Amount"), note, isActive);
    }

    public void SetCategoryName(string name)
    {
        CategoryName = name;
    }
}
