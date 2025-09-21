using AMartinezTech.Core.Utils; 

namespace AMartinezTech.Application.Setting.DocIdentity;

public class DocIdentityQueries(IDocIdentityReadRepository repository)
{
    private readonly IDocIdentityReadRepository _repository = repository;

    public async Task<PageResult<DocIdentityDto>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = DocIdentityMapper.ToDtoList(result.Data);

        return new PageResult<DocIdentityDto>(result.TotalRecords, pageSize, dtoList);
    }
}
