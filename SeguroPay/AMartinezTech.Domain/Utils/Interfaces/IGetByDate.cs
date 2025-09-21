namespace AMartinezTech.Domain.Utils.Interfaces;

public interface IGetByDate<T> where T : class, IAggregateRoot
{
    Task<IReadOnlyList<T>> PaginationAsync(DateTime initialDate, DateTime endDate, bool? isActived);

}
