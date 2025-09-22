using AMartinezTech.Application.Client.Interfaces;

namespace AMartinezTech.Application.Client.UseCases.Read;

public class ClientFilter(IClientReadRepository repository)
{
    private readonly IClientReadRepository _repository = repository;
    public async Task<IReadOnlyList<ClientDto>> ExecuteAsync(string? filter, bool? isActived)
    {
        var result = await _repository.FilterAsync(filter, isActived);
        return ClientMapper.ToDtoList(result);
    }
}
