namespace AMartinezTech.Domain.Utils.Interfaces;

public interface IPagination<T> where T : class, IAggregateRoot
{
    Task<PageResult<T>> PaginationAsync(int pageNumber, int pageSize, bool? isActived);
}
