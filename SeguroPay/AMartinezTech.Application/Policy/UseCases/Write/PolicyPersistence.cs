using AMartinezTech.Application.Policy.Interfaces;
using AMartinezTech.Domain.Policy;

namespace AMartinezTech.Application.Policy.UseCases.Write;

public class PolicyPersistence(IPolicyWriteRepository repository)
{
    private readonly IPolicyWriteRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(PolicyDto dto)
    {
        var entity = PolicyEntity.Create(
            dto.Id,
            dto.PolicyNo,
            dto.CreatedAt,
            dto.UpdatedAt,
            dto.ClientId,
            dto.InsuranceId,
            dto.TypeId,
            dto.PayDay,
            dto.PayFrencuency,
            dto.Amount,
            dto.Status,
            dto.Note,
            dto.CreatedBy,
            dto.ActivateBy,
            dto.SuspendBy,
            dto.CancelBy);

        if (dto.Id == Guid.Empty) { await _repository.CreateAsync(entity); } else { await _repository.UpdateAsync(entity); }

        return entity.Id;
    }
}
