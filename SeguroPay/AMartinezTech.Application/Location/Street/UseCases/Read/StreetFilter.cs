using AMartinezTech.Application.Location.Street.Interfaces;

namespace AMartinezTech.Application.Location.Street.UseCases.Read;

public class StreetFilter(IStreetReadRepository repository)
{
    private readonly IStreetReadRepository _repository = repository;

    public async Task<List<StreetDto>> ExecuteAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? isActived = null)
    {
        var result = await _repository.FilterAsync(filters,globalSearch, isActived);
        return StreetMapper.ToDtoList(result);
    }
}
