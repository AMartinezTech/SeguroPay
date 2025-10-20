using AMartinezTech.Domain.Policy;
using AMartinezTech.Domain.Utils.Exception; 

namespace AMartinezTech.Application.Policy.Type;
  
public class PolicyTypeApplicationServices(IPolicyTypeReadRepository readRepsitory, IPolicyTypeWriteRepository writeRepository)
{
    private readonly IPolicyTypeReadRepository _readRepsitory = readRepsitory;
    private readonly IPolicyTypeWriteRepository _writeRepository = writeRepository;

    #region "Read"
    public async Task<List<PolicyTypeDto>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? search = null, bool? isActive = null)
    {
        var result = await _readRepsitory.FilterAsync(filters, search, isActive);
        return PolicyTypeMapper.ToDtoList(result);
    }
    private async Task<PolicyTypeEntity> GetById(Guid id)
    {
        return await _readRepsitory.GetByIdAsync(id) ?? throw new Exception($"{ErrorMessages.Get(ErrorType.RecordDoesDotExist)} - PolicyType");
    }
    public async Task<PolicyTypeDto> GetByIdAsync(Guid id)
    {
        var result = await GetById(id);
        return PolicyTypeMapper.ToDto(result);
    }
    #endregion
    #region "Write"
    public async Task<Guid> PersistenceAsync(PolicyTypeDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto, nameof(dto));

        PolicyTypeEntity entity;

        // Create
        if (dto.Id == Guid.Empty)
        {
            entity = PolicyTypeEntity.Create(dto.Id,dto.Name, dto.InsuranceId);

            await _writeRepository.CreateAsync(entity);
        }
        // Update
        else
        {
            entity = await GetById(dto.Id);
              
            entity.Update(dto.Name, dto.InsuranceId, dto.IsActive);

            await _writeRepository.UpdateAsync(entity);
        }

        return entity.Id;
    }
    #endregion
}
