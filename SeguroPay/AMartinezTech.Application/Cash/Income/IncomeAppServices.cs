using AMartinezTech.Application.Policy.Interfaces;
using AMartinezTech.Application.Setting.User.Interfaces;
using AMartinezTech.Application.Utils.Interfaces;
using AMartinezTech.Domain.Cash.Income;
using AMartinezTech.Domain.Utils.Exception;

namespace AMartinezTech.Application.Cash.Income;

public class IncomeAppServices(IIncomeReadRepository readRepository, IIncomeWriteRepository writeRepository, ICurrectUser currectUser, IServerTimeProvider serverTimeProvider, IPolicyReadRepository policyReadRepository)
{
    private readonly IIncomeReadRepository _readRepository = readRepository;
    private readonly IIncomeWriteRepository _writeRepository = writeRepository;
    private readonly ICurrectUser _currectUser = currectUser;
    private readonly IServerTimeProvider _serverTimeProvider = serverTimeProvider;
    private readonly IPolicyReadRepository _policyReadRepository = policyReadRepository;

    #region "Read"
    public async Task<List<IncomeDto>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? search = null, Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null)
    {
        var result = await _readRepository.FilterAsync(filters, search, dateRanges);
        return IncomeMapper.ToDtoList(result);
    }
    private async Task<IncomeEntity> GetIncomeById(Guid id)
    {
        return await _readRepository.GetByIdAsync(id) ?? throw new Exception($"{ErrorMessages.Get(ErrorType.RecordDoesDotExist)} - Income");
    }
    public async Task<IncomeDto> GetByIdAsync(Guid id)
    {
        var result = await GetIncomeById(id);
        return IncomeMapper.ToDto(result);
    }
    #endregion

    #region "Write"
    public async Task<Guid> PersistenceAsync(IncomeDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto, nameof(dto));

        IncomeEntity entity;
        if (dto.Id == Guid.Empty)
        {
            // Traer la póliza desde el repositorio
            var policyEntity = await _policyReadRepository.GetByIdAsync(dto.PolicyId) ?? throw new Exception($"{ErrorMessages.Get(ErrorType.RecordDoesDotExist)} - Policy");

            // Obtener la fecha actual del servidor (no del cliente)
            var currentServerDateTime = await _serverTimeProvider.GetServerDateTimeAsync();

            // Ajustar el día de pago, manteniendo la hora actual del servidor
            // (si el día de pago no existe en el mes actual, se usa el último día disponible)
            var lastDayOfMonth = DateTime.DaysInMonth(currentServerDateTime.Year, currentServerDateTime.Month);
            var safeDay = Math.Min(policyEntity.PaymentDay.Value, lastDayOfMonth);

            var adjustedDate = new DateTime(currentServerDateTime.Year, currentServerDateTime.Month, safeDay, currentServerDateTime.Hour, currentServerDateTime.Minute, currentServerDateTime.Second);

            // Crear el IncomeEntity con las fechas ajustadas
            entity = IncomeEntity.Create(
                Guid.Empty, adjustedDate, currentServerDateTime, dto.PolicyId, dto.ClientId, dto.IncomeType, dto.PaymentMethod, dto.MadeIn, _currectUser!.User!.Id, dto.Amount, dto.Note);

            // Guardar el ingreso
            await _writeRepository.CreateAsync(entity);
        }
        else
        {
            entity = await GetIncomeById(dto.Id);
            entity.Update(dto.PaymentMethod, dto.MadeIn, dto.Note);
            await _writeRepository.UpdateAsync(entity);
        }


        return entity.Id;
    }
    public async Task DeleteAsync(Guid id)
    {
        _ = await GetIncomeById(id);
        await _writeRepository.DeleteAsync(id);
    }
    #endregion
}
