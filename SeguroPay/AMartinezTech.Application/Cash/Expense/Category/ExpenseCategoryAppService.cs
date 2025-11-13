using AMartinezTech.Domain.Cash.Expense;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exception;
using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Application.Cash.Expense.Category;

public class ExpenseCategoryAppService(IExpenseCategoryReadRepository readRepository, IExpenseCategoryWriteRepository writeRepository)
{
    private readonly IExpenseCategoryReadRepository _readRepository = readRepository;
    private readonly IExpenseCategoryWriteRepository _writeRepository = writeRepository; 

    #region "Read"
    public async Task<PageResult<ExpenseCategoryDto>> PaginationAsync(int pageNumber, int pageSize, bool? IsActive)
    {
        var result = await _readRepository.PaginationAsync(pageNumber, pageSize, IsActive);
        var dtoList = ExpenseCategoryMapper.ToDtoList(result.Data);
        return new PageResult<ExpenseCategoryDto>(result.TotalRecords, pageSize, dtoList);
    }
    public async Task<ExpenseCategoryDto> GetByIdAsync(Guid id)
    {
        var result = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($" {ErrorMessages.Get(ErrorType.RequiredField)} - Id ");
        return ExpenseCategoryMapper.ToDto(result);
    }
    #endregion

    #region "Write"
    public async Task<Guid> PersistenceAsync(ExpenseCategoryDto dto)
    {
        var entity = ExpenseCategoryEntity.Create(
            dto.Id,
            dto.Name,
            dto.IsActive
            );

        if (dto.Id == Guid.Empty) { await _writeRepository.CreateAsync(entity); } else { await _writeRepository.UpdateAsync(entity); }

        return entity.Id;
    }
    #endregion
}
