using AMartinezTech.Application.Client.Interfaces;
using AMartinezTech.Domain.Client;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exception;

namespace AMartinezTech.Application.Client;

public class ClientAppServices(IClientReadRepository readRepository, IClientWriteRepository writeRepository)
{
    private readonly IClientReadRepository _readRepository = readRepository;
    private readonly IClientWriteRepository _writeRepository = writeRepository;

    #region "Read"
    public async Task<IReadOnlyList<ClientDto>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null)
    {
        var result = await _readRepository.FilterAsync(filters, globalSearch);
        return ClientMapper.ToDtoList(result);
    }
    public async Task<ClientDto> GetByIdAsync(Guid id)
    {
        var result = await _readRepository.GetByIdAsync(id) ?? throw new Exception($"{ErrorMessages.Get(ErrorType.RecordDoesDotExist)} - Client");
        return ClientMapper.ToDto(result);
    }
    public async Task<PageResult<ClientDto>> PaginationAsync(int pageNumber, int pageSize, bool? IsActive)
    {
        var result = await _readRepository.PaginationAsync(pageNumber, pageSize, IsActive);
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
            dto.IsActive,
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
            dto.IsActive,
            dto.ContactName ?? string.Empty,
            dto.ContactPhone ?? string.Empty,
            dto.CityId,
            dto.StreetId
        );
        await _writeRepository.UpdateAsync(entity);

    }

    #endregion
}
