using AMartinezTech.Core.Utils;

namespace AMartinezTech.Core.Interfaces;

public interface IPagination<T> where T : class, IAggregateRoot
{
    Task<PagedResult<T>> PaginationAsync(int pageNumber, int pageSize, bool? isActived);
}
