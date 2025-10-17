using AMartinezTech.Application.Location.Street.Interfaces;
using AMartinezTech.Domain.Location.Entities; 

namespace AMartinezTech.Application.Location.Street;

public class StreetApplicationService(IStreetReadRepository readRepository, IStreetWriteRepository writeRepository)
{
    private readonly IStreetReadRepository _readRepository = readRepository;
    private readonly IStreetWriteRepository _writeRepository = writeRepository;

    #region "Read"
    public async Task<List<StreetDto>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? IsActive = null)
    {
        var result = await _readRepository.FilterAsync(filters, globalSearch, IsActive);
        return StreetMapper.ToDtoList(result);
    }
    
    public async Task<StreetDto> StreetGetByIdAsync(Guid id)
    {
        var result = await _readRepository.GetByIdAsync(id);
        return StreetMapper.ToDto(result);
    }
    #endregion

    #region "Write" 
    public async Task<Guid> PersistenceAsync(StreetDto dto)
    {
        if (dto.Id == Guid.Empty)
        {
            return await CreateAsync(dto);
        }
        else
        {
            await UpdateAsync(dto);
            return dto.Id;
        }
    }
     
    private async Task<Guid> CreateAsync(StreetDto dto)
    {
        var entity = StreetEntity.Create(dto.Id,dto.CityId,dto.Name,DateTime.Now);
        await _writeRepository.CreateAsync(entity);
        return entity.Id;
    }
    private async Task UpdateAsync(StreetDto dto)
    {
        var entity = StreetEntity.Create(dto.Id, dto.CityId, dto.Name, DateTime.Now);
        await _writeRepository.UpdateAsync(entity);
    }

    #endregion

}
