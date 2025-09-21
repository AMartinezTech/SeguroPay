namespace AMartinezTech.Domain.Utils.Interfaces;

public interface IUpdate<T> where T : class, IAggregateRoot
{
    Task UpdateAsync(T entity);
}
