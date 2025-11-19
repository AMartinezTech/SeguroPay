using AMartinezTech.Application.Cash.Expense.Interfaces;
using AMartinezTech.Application.Setting.User.Interfaces;
using AMartinezTech.Domain.Cash.Expense;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Application.Cash.Expense;

public class ExpenseAppService(IExpenseReadRepository readRepository, IExpenseWriteRepository writeRepository ,ICurrectUser currectUser)
{
    private readonly IExpenseReadRepository _repository = readRepository;
    private readonly IExpenseWriteRepository _writeRepository = writeRepository;
    private readonly ICurrectUser _currectUser = currectUser;


    #region "Read"
    public async Task<PageResult<ExpenseDto>> PaginationAsync(int pageNumber, int pageSize, bool? IsActive)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, IsActive);
        var dtoList = ExpenseMapper.ToDtoList(result.Data);

        return new PageResult<ExpenseDto>(result.TotalRecords, pageSize, dtoList);
    }

    public async Task<List<ExpenseDto>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? search = null, Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null)
    {
        var result = await _repository.FilterAsync(filters, search, dateRanges);
        return ExpenseMapper.ToDtoList(result);
    }

    public async Task<ExpenseDto> GetByIdAsync(Guid id)
    {
        var result = await _repository.GetByIdAsync(id) ?? throw new ValidationException($" {ErrorMessages.Get(ErrorType.RecordDoesDotExist)} - Expense "); 
        return ExpenseMapper.ToDto(result);
    }
    #endregion

    #region "Write"
    public async Task<Guid> PersistenceASync(ExpenseDto dto)
    {
        Guid UserId = Guid.Empty;

        if (_currectUser.IsLoggedIn)
            UserId = _currectUser.User!.Id;

       var entity = ExpenseEntity.Create(dto.Id, dto.CreatedAt, dto.CategoryId, dto.Amount, dto.Note, dto.IsActive, UserId);

        if (dto.Id == Guid.Empty)
        {
            await _writeRepository.CreateAsync(entity);
        }
        else
        {
            await _writeRepository.UpdateAsync(entity);
        }

        return entity.Id;
    }
    #endregion
}