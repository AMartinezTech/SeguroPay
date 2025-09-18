namespace AMartinezTech.Core.Interfaces;

public interface ICreate<T> where T : class, IAggregateRoot
{
    Task CreateAsync(T entity);
}
