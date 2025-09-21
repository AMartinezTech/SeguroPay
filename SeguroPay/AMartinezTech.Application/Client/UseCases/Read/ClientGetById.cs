using AMartinezTech.Application.Client.Interfaces;

namespace AMartinezTech.Application.Client.UseCases.Read;

public class ClientGetById(IClientReadRepository repository)
{
    private readonly IClientReadRepository _repository = repository;

    public async Task<ClientDto> FilterAsync(Guid id)
    {
        var result = await _repository.GetById(id);
        return ClientMapper.ToDto(result);
    }
}
