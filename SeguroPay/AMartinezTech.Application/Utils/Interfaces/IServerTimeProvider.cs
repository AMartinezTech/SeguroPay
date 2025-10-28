namespace AMartinezTech.Application.Utils.Interfaces;

public interface IServerTimeProvider
{
    Task<DateTime> GetServerDateTimeAsync();
}