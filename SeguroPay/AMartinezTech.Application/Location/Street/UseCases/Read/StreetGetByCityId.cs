using AMartinezTech.Application.Location.Street.Interfaces;

namespace AMartinezTech.Application.Location.Street.UseCases.Read;

public class StreetGetByCityId(IStreetReadRepository repository)
{
    private readonly IStreetReadRepository _repository = repository;

    public async Task<List<StreetDto>> ExecuteAsync(Guid cityId)
    {
        var result = await _repository.GetByCityId(cityId);
        return StreetMapper.ToDtoList(result);
    }
}