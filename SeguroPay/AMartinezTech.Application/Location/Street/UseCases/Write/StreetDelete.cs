using AMartinezTech.Application.Location.Street.Interfaces;

namespace AMartinezTech.Application.Location.Street.UseCases.Write;

public class StreetDelete(IStreetWriteRepository repository)
{
    private readonly IStreetWriteRepository _repository = repository;
    public async Task ExecuteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
