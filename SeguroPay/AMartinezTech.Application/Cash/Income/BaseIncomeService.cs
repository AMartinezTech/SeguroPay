
using AMartinezTech.Application.Setting.User.Interfaces; 
using AMartinezTech.Domain.Cash.Income; 

namespace AMartinezTech.Application.Cash.Income;

public abstract class BaseIncomeService(IIncomeWriteRepository writeRepository, ICurrectUser currentUser)
{

    protected readonly IIncomeWriteRepository _writeRepository = writeRepository;
    protected readonly ICurrectUser _currentUser = currentUser;
    
    
    
    /// <summary>
    /// Método común para guardar el ingreso en la base de datos.
    /// </summary>
    protected async Task<Guid> SaveIncomeAsync(IncomeEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        await _writeRepository.CreateAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// Crea la entidad base de ingreso, usada por las clases hijas.
    /// </summary>
    protected  IncomeEntity CreateBaseIncomeAsync(
        DateTime paymentDate,
        DateTime currentServerDateTime,
        Guid? policyId,
        Guid clientId,
        string incomeType,
        string paymentMethod,
        string madeIn,
        decimal amount,
        string? note)
    {
        // Obtener fecha actual del servidor
       
        return IncomeEntity.Create(
            Guid.Empty,
            paymentDate,
            currentServerDateTime, // o puedes delegar al server si es requerido
            policyId,
            clientId,
            incomeType,
            paymentMethod,
            madeIn,
            _currentUser.User!.Id,
            amount,
            note
        );
    }
}
