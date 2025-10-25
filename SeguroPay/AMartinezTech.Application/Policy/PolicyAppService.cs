using AMartinezTech.Application.Policy.DTOs;
using AMartinezTech.Application.Policy.Interfaces;
using AMartinezTech.Application.Policy.Mappers;
using AMartinezTech.Application.Setting.User.Interfaces;
using AMartinezTech.Domain.Policy; 
using AMartinezTech.Domain.Utils.Exception;

namespace AMartinezTech.Application.Policy;

public class PolicyAppService(IPolicyReadRepository readRepository, IPolicyWriteRepository writeRepository, ICurrectUser currectUser)
{
    private readonly IPolicyReadRepository _readRepository = readRepository;
    private readonly IPolicyWriteRepository _writeRepository = writeRepository;
    private readonly ICurrectUser _currectUser = currectUser;

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
    public async Task<List<PolicyDto>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null)
    {
        var result = await _readRepository.FilterAsync(filters, globalSearch);
        return PolicyMapper.ToDtoList(result);
    }

    public async Task<IReadOnlyCollection<PendingPaymentDto>> GetPendingPaymentsAsync(Guid policyId, DateTime currentDate)
    {
        // 1. Obtener la póliza con sus pagos
        var policy = await _readRepository.GetByIdAsync(policyId) ?? throw new Exception($"{ErrorMessages.Get(ErrorType.RecordDoesDotExist)} - Policy");

        // 2. Llamar al servicio de dominio para calcular pagos pendientes
        var pendientes = PolicyPaymentCalculatorService.GetPendingPayments(
            policy,
            policy.Payments,
            currentDate
        );

        // 3. Mapear a DTO para la capa de presentación
        return [.. pendientes.Select(p => new PendingPaymentDto
        {
            PolicyId = p.PolicyId,
            PaymentDate = p.PaymentDate,
            Amount = p.Amount
        })];
    }
    #endregion

    #region "Write"
    public async Task<Guid> PersistenceAsync(PolicyDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto, nameof(dto));


        PolicyEntity entity;

        //Create
        if (dto.Id == Guid.Empty)
        {

            var existingPolicyNo = await _readRepository.ExistsByPolicyNoAsync(dto.PolicyNo);
            if (existingPolicyNo)
                throw new Exception("El número de póliza ya existe.! - PolicyNo");

             
            var existingPolicy = await _readRepository.ExistsByClientAndTypeAsync(dto.ClientId, dto.PolicyType);
            if (existingPolicy)
                throw new Exception("El cliente ya tiene una póliza registrada.");


            entity = PolicyEntity.Create(
                Guid.Empty,
                 dto.PolicyNo,
                 dto.PolicyType,
                 dto.InsuranceId,
                 dto.ClientId,
                 dto.PaymentFrequency, 
                 dto.PaymentDay,
                 dto.PaymentInstallment,
                 dto.Amount,
                 dto.Note
                 );
            
            await _writeRepository.CreateAsync(entity);

        }
        // Update
        else
        {
            entity = await GetPolicyById(dto.Id);

            entity.UpdatePolicy(dto.PolicyNo, dto.PolicyType, dto.InsuranceId, dto.PaymentFrequency, dto.PaymentDay, dto.Amount, dto.Note,   dto.ClientId,dto.PaymentInstallment);

            await _writeRepository.UpdateAsync(entity);

        }

        return entity.Id;

    }

    public async Task ActiveAsync(Guid id)
    {
        var entity = await GetPolicyById(id);
        entity.Activate();
        await _writeRepository.UpdateAsync(entity);
    }

    public async Task SuspendAsync(Guid id, bool authorized)
    {
        var entity = await GetPolicyById(id);
        entity.Suspend(authorized);
        await _writeRepository.UpdateAsync(entity);
    }

    public async Task CancelAsync(Guid id,  bool authorized)
    {
        var entity = await GetPolicyById(id);
        entity.Cancel(authorized);
        await _writeRepository.UpdateAsync(entity);
    }
    #endregion
}
