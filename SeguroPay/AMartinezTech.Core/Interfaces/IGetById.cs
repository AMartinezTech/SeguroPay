namespace AMartinezTech.Core.Interfaces;

public interface IGetById<T, Tid> where T : class, IAggregateRoot
{
    Task<T> GetById(Tid id);
}
