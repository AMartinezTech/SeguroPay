namespace AMartinezTech.Domain.Utils.Interfaces;

public interface IFilter<T> where T : class, IAggregateRoot
{
    Task<IReadOnlyList<T>> FilterAsync(string? filterStr, bool? isActived);
}
