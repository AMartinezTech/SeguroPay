using AMartinezTech.Application.Insurance.Interfaces;
using AMartinezTech.Domain.Insurance;
using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exception;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Application.Insurance;

public class InsuranceApplicationServices(IInsuranceReadRepository readRepository, IInsuranceWriteRepository writeRepository)
{
    private readonly IInsuranceReadRepository _readRepository = readRepository;
    private readonly IInsuranceWriteRepository _writeRepository = writeRepository;

    #region "Writer"
    public async Task<Guid> PersistenceAsync(InsuranceDto dto)
    {

        var address = ValueAddress.Create(dto.CountryId, dto.RegionId, dto.CityId, dto.StreetId);
        if (dto.Id == Guid.Empty)
        {
            var entity = InsuranceEntity.Create(
                dto.Id,
                dto.CreatedAt,
                dto.Name,
                address,
                dto.Email,
                dto.Phone,
                dto.ContactName ?? string.Empty,
                dto.ContactPhone ?? string.Empty,
                dto.IsActived
                );
            await _writeRepository.CreateAsync(entity);
            return entity.Id;
        }
        else
        {
            var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new Exception(ErrorMessages.Get(ErrorType.RecordDoesDotExist));
            entity.Update(dto.Name, address, dto.Email, dto.Phone, dto.ContactName, dto.ContactPhone);
            await _writeRepository.UpdateAsync(entity);
            return entity.Id;
        }

    }

    public async Task MarkAsInactive(Guid id)
    {
        var entity = await _readRepository.GetByIdAsync(id) ?? throw new Exception(ErrorMessages.Get(ErrorType.RecordDoesDotExist));

        entity.MarkAsInactivate();
        await _writeRepository.UpdateAsync(entity);
    }

    public async Task MarkAsActive(Guid id)
    {
        var entity = await _readRepository.GetByIdAsync(id) ?? throw new Exception(ErrorMessages.Get(ErrorType.RecordDoesDotExist));

        entity.MarkAsActivate();
        await _writeRepository.UpdateAsync(entity);
    }
    #endregion

    #region "Read"
    public async Task<PageResult<InsuranceDto>> PaginationAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _readRepository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = InsuranceMapper.ToDtoList(result.Data);

        return new PageResult<InsuranceDto>(result.TotalRecords, pageSize, dtoList);
    }

    public async Task<InsuranceDto> GetByIdAsync(Guid id)
    {
        var result = await _readRepository.GetByIdAsync(id) ?? throw new Exception(ErrorMessages.Get(ErrorType.RecordDoesDotExist));
        return InsuranceMapper.ToDto(result);
    }

    public async Task<List<InsuranceDto>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? globalSearch = null, bool? isActived = null)
    {
        var result = await _readRepository.FilterAsync(filters, globalSearch, isActived);
        return InsuranceMapper.ToDtoList(result);
    }
    #endregion
}
