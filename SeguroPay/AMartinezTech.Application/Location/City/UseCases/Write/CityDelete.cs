using AMartinezTech.Application.Location.City.Interfaces;

namespace AMartinezTech.Application.Location.City.UseCases.Write;

public class CityDelete(ICityWriteRepository repository)
{
    private readonly ICityWriteRepository _repository = repository;

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
