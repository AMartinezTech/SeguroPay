using AMartinezTech.Domain.Bank;
using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Application.Bank;

public class BankAccountAppService(IBankAccountReadRepository readRepository, IBankAccountWriteRepository writerRepository)
{
    private readonly IBankAccountReadRepository _readRepository = readRepository;
    private readonly IBankAccountWriteRepository _writerRepository = writerRepository;

    #region "Read"
    #endregion

    #region "Write"
    public async Task AddMovementAsync(Guid bankAccountId, BankAccountMovementDto movementDto)
    {
        // 1) Cargar entidad desde el ReadRepository
        var entity = await _readRepository.GetByIdAsync(bankAccountId)
            ?? throw new ValidationException($" {ErrorMessages.Get(ErrorType.RecordDoesDotExist)} - BankAccount ");

        // 2) Crear el movimiento usando el AggregateRoot (cumple DDD)
        var movement = entity.AddMovement(
            movementDto.CreatedAt,
            movementDto.MovementTypes,
            movementDto.Amount,
            movementDto.Description,
            movementDto.CreatedBy,
            movementDto.CreatedByName
        );

        // 3) Persistir solo el movimiento nuevo (no toda la entidad)
        await _writerRepository.AddMovementAsync(movement);

        // 4) OPTIONAL: actualizar la cuenta si cambió HasMovements
        if (entity.HasMovements)
        {
            await _writerRepository.UpdateAsync(entity);
        }
    }
    public async Task RemoveMovementAsync(Guid movementId)
    {
        await _writerRepository.RemoveMovementAsync(movementId);
    }
    public async Task<Guid> PersistenceAsync(BankAccountDto dto)
    {
        // Buscar si existe
        var entity = await _readRepository.GetByIdAsync(dto.Id);

        if (entity is null)
        {
            // Crear
            entity = BankAccountEntity.Create(
                dto.Id,
                dto.CreatedAt,
                dto.Name,
                dto.Number,
                dto.Type,
                dto.ContactName,
                dto.ContactPhone,
                dto.IsActive
            );

            await _writerRepository.CreateAsync(entity);
        }
        else
        {
            // Si la cuenta tiene movimientos, tu dominio ya lanza excepción
            // así que NO necesitas manejarlo aquí.

            entity.Update(
                dto.Name,
                dto.Number,
                dto.Type,
                dto.ContactName,
                dto.ContactPhone,
                dto.IsActive
            );

            await _writerRepository.UpdateAsync(entity);
        }

        return entity.Id;
    }
    public async Task DeleteAsync(Guid bankAccountId)
    {
        // 1) Cargar entidad desde el ReadRepository
        var entity = await _readRepository.GetByIdAsync(bankAccountId)
            ?? throw new ValidationException($" {ErrorMessages.Get(ErrorType.RecordDoesDotExist)} - BankAccount ");

        entity.EnsureNoMovementsBeforeDelete();


        await _writerRepository.DeleteAsync(bankAccountId);


    }

    #endregion

}
