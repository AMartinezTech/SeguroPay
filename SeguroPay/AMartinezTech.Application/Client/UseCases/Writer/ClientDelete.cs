namespace AMartinezTech.Application.Client.UseCases.Writer;

public class ClientDelete(IClientWriteRepository repository)
{
    private readonly IClientWriteRepository _repository = repository;

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
