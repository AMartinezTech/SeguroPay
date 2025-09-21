namespace AMartinezTech.Domain.Utils.Interfaces;

public interface ICreate<T> where T : class, IAggregateRoot
{
    Task CreateAsync(T entity);
}
