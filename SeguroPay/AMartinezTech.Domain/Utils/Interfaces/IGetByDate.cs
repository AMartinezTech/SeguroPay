using AMartinezTech.Core.Utils;

namespace AMartinezTech.Domain.Utils.Interfaces;

public interface IGetByDate<T> where T : class, IAggregateRoot
{
    Task<ByDateResult<T>> GetByDateAsync(DateTime initialDate, DateTime endDate, bool? isActived);

}
