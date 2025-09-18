namespace AMartinezTech.Core.Interfaces;

public interface IDelete<Tid> 
{
    Task DeleteAsync(Tid id);
}
