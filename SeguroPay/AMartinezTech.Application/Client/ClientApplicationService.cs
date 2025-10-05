using AMartinezTech.Application.Client.Interfaces;
using AMartinezTech.Domain.Client.Entitties;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Application.Client;

public class ClientApplicationService(IClientReadRepository readRepository, IClientWriteRepository writeRepository)
{
    private readonly IClientReadRepository _readRepository = readRepository;
    private readonly IClientWriteRepository _writeRepository = writeRepository;

    #region "Read"
    public async Task<IReadOnlyList<ClientDto>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? isActived = null)
    {
        var result = await _readRepository.FilterAsync(filters, globalSearch, isActived);
        return ClientMapper.ToDtoList(result);
    }
    public async Task<ClientDto> GetByIdAsync(Guid id)
    {
        var result = await _readRepository.GetByIdAsync(id);
        return ClientMapper.ToDto(result);
    }
    public async Task<PageResult<ClientDto>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _readRepository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = ClientMapper.ToDtoList(result.Data);

        return new PageResult<ClientDto>(result.TotalRecords, pageSize, dtoList);
    }
    #endregion

    #region "Write"
    public async Task<Guid> PersistenceAsync(ClientDto dto)
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
    private async Task<Guid> CreateAsync(ClientDto dto)
    {
         
        var entity = ClientEntity.Create(
            dto.Id,
            dto.DocIdentityType,
            dto.ClientType,
            dto.DocIdentity,
            dto.FirstName,
            dto.LastName, 
            dto.Phone,
            dto.Email,
            dto.Observation ?? string.Empty,
            dto.LocationNo ?? string.Empty,
            dto.AddressRef ?? string.Empty,
            dto.IsActived,
            dto.ContactName ?? string.Empty,
            dto.ContactPhone ?? string.Empty,
            dto.CityId,
            dto.StreetId
        );
        await _writeRepository.CreateAsync(entity);
        return entity.Id;
    }
    private async Task UpdateAsync(ClientDto dto)
    {
       
        var entity = ClientEntity.Create(
            dto.Id,
            dto.DocIdentityType,
            dto.ClientType,
            dto.DocIdentity,
            dto.FirstName,
            dto.LastName, 
            dto.Phone,
            dto.Email,
            dto.Observation ?? string.Empty,
            dto.LocationNo ?? string.Empty,
            dto.AddressRef ?? string.Empty,
            dto.IsActived,
            dto.ContactName ?? string.Empty,
            dto.ContactPhone ?? string.Empty,
            dto.CityId,
            dto.StreetId
        );
        await _writeRepository.UpdateAsync(entity);

    }

    #endregion
}
