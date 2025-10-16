namespace AMartinezTech.Domain.Utils.Interfaces;

public interface IGetById<T, Tid> where T : class, IAggregateRoot
{
    Task<T?> GetByIdAsync(Tid id);
}
