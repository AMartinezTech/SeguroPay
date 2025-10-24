namespace AMartinezTech.Domain.Utils.Interfaces;

public interface IFilter<T> where T : class, IAggregateRoot
{
    Task<IReadOnlyList<T>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? search = null,  Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null);
}
