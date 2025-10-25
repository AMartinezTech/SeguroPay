using AMartinezTech.Domain.Cash.Income;
using AMartinezTech.Domain.Utils.Exception;

namespace AMartinezTech.Application.Cash.Income;

public class IncomeAppServices(IIncomeReadRepository readRepository, IIncomeWriteRepository writeRepository)
{
    private readonly IIncomeReadRepository _readRepository = readRepository;
    private readonly IIncomeWriteRepository _writeRepository = writeRepository;

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
          
        entity = IncomeEntity.Create(
            Guid.Empty, dto.PaymentDate, dto.CreatedAt, dto.DocIdRelated, dto.IncomeType, dto.PaymentMethod, dto.MadeIn, dto.CreatedBy, dto.Amount

             );

        await _writeRepository.CreateAsync(entity);

         
        return entity.Id;
    }
    public async Task DeleteAsync(Guid id)
    {
        IncomeEntity entity = await GetIncomeById(id);
        await _writeRepository.DeleteAsync(id);
    }
    #endregion
}
