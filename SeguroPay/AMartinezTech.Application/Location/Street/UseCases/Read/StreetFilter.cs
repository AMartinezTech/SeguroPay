using AMartinezTech.Application.Location.Street.Interfaces;

namespace AMartinezTech.Application.Location.Street.UseCases.Read;

public class StreetFilter(IStreetReadRepository repository)
{
    private readonly IStreetReadRepository _repository = repository;

    public async Task<List<StreetDto>> ExecuteAsync(string? filterStr, bool? isActived)
    {
        var result = await _repository.FilterAsync(filterStr, isActived);
        return StreetMapper.ToDtoList(result);
    }
}
