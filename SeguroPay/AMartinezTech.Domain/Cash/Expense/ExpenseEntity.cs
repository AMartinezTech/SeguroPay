using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Cash.Expense;

public class ExpenseEntity : IAggregateRoot
{
    public Guid Id { get; private set; }
    public ValueGuid CategoryId { get; private set; }
    public ValuePositiveNum Amount { get; private set; }
    public string Note { get; private set; }
    public bool IsActived { get; private set; }

    private ExpenseEntity(Guid id, ValueGuid categoryId, ValuePositiveNum amount, string note, bool isActived)
    {
        Id = id;
        CategoryId = categoryId;
        Amount = amount;
        Note = note;
        IsActived = isActived;
    }

    public static ExpenseEntity Create(Guid id, Guid categoryId, decimal amount, string note, bool isActived)
    {
        id = CreateGuid.EnsureId(id);
        return new ExpenseEntity(id, ValueGuid.Create(categoryId,"categoría"), ValuePositiveNum.Create(amount,"monto"), note, isActived);
    }
}
