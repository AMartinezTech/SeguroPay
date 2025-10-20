using AMartinezTech.Application.Policy.Interfaces;
using AMartinezTech.Domain.Policy;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.Exception;

namespace AMartinezTech.Application.Policy;

public class PolicyApplicationService(IPolicyReadRepository readRepository, IPolicyWriteRepository writeRepository)
{
    private readonly IPolicyReadRepository _readRepository = readRepository;
    private readonly IPolicyWriteRepository _writeRepository = writeRepository;

    #region "Read"
    private async Task<PolicyEntity> GetPolicyById(Guid id)
    {
        return await _readRepository.GetByIdAsync(id) ?? throw new Exception($"{ErrorMessages.Get(ErrorType.RecordDoesDotExist)} - Policy");
    }
    public async Task<PolicyDto> GetByIdAsync(Guid id)
    {
        var result = await GetPolicyById(id);
        return PolicyMapper.ToDto(result);
    }
    public async Task<List<PolicyDto>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? IsActive = null)
    {
        var result = await _readRepository.FilterAsync(filters, globalSearch, IsActive);
        return PolicyMapper.ToDtoList(result);
    }
    #endregion

    #region "Write"
    public async Task<Guid> PersistenceAsync(PolicyDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        // Verificar si el cliente ya tiene una póliza
        var existingPolicy = await _readRepository.GetByClientIdAsync(dto.ClientId);
        if (!existingPolicy)
            throw new Exception("El cliente ya tiene una póliza registrada.");

        if (!Enum.TryParse(dto.PayFrencuency, out PolicyPayFrencuency payFrecuency)) throw new Exception($"{ErrorMessages.Get(ErrorType.InvalidType)} - PayFrencuency");
        if (!Enum.TryParse(dto.Status, out PolicyStatusType status)) throw new Exception($"{ErrorMessages.Get(ErrorType.InvalidType)} - Status");

        PolicyEntity entity;

        //Create
        if (dto.Id == Guid.Empty)
        {
            entity = PolicyEntity.Create(Guid.Empty,
             dto.PolicyNo,
             dto.PolicyTypeId,
             dto.ClientId,
             dto.InsuranceId,
             payFrecuency,
             dto.PayDay,
             dto.Amount,
             dto.Note,
             dto.CreatedAt,
             dto.UpdatedAt,
             status,
             dto.CreatedBy);

            await _writeRepository.CreateAsync(entity);

        }
        // Update
        else
        {
            entity = await GetPolicyById(dto.Id);

            entity.UpdatePolicy(dto.PolicyNo, dto.PolicyTypeId, dto.InsuranceId, payFrecuency, dto.PayDay, dto.Amount, dto.Note);

            await _writeRepository.UpdateAsync(entity);

        }

        return entity.Id;

    }

    public async Task ActiveAsync(Guid id, Guid userId)
    {
        var entity = await GetPolicyById(id);
        entity.Activate(userId);
        await _writeRepository.UpdateAsync(entity);
    }

    public async Task SuspendAsync(Guid id, Guid userId, bool authorized)
    {
        var entity = await GetPolicyById(id);
        entity.Suspend(userId, authorized);
        await _writeRepository.UpdateAsync(entity);
    }

    public async Task CancelAsync(Guid id, Guid userId, bool authorized)
    {
        var entity = await GetPolicyById(id);
        entity.Cancel(userId, authorized);
        await _writeRepository.UpdateAsync(entity);
    }

    
    #endregion
}
