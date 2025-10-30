using AMartinezTech.Domain.Setting.Company;
using AMartinezTech.Domain.Utils.Exception;

namespace AMartinezTech.Application.Setting.Company;

public class CompanyAppServices(ICompanyReadRepository readRepository, ICompanyWriteRepository writeRepository)
{
    public readonly ICompanyReadRepository _readRepository = readRepository;
    public readonly ICompanyWriteRepository _writeRepository = writeRepository;

    #region "Read"
    public async Task<List<CompanyDto>> FilterAsync()
    {
        var result = await _readRepository.FilterAsync();
        return CompanyMapper.ToDtoList(result);
    }
    private async Task<CompanyEntity> GetCompanyByIdAsync(Guid companyId)
    {
        return await _readRepository.GetByIdAsync(companyId) ?? throw new Exception($"{ErrorMessages.Get(ErrorType.RecordDoesDotExist)} - Company");
    }

    public async Task<CompanyDto> GetByIdAsync(Guid companyId)
    {
        return CompanyMapper.ToDto(await GetCompanyByIdAsync(companyId));
    }
    #endregion


    #region "Write"
    public async Task<Guid> PersistenceAsync(CompanyDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        CompanyEntity entity;

        if (dto.Id == Guid.Empty)
        {
            entity = CompanyEntity.Create(dto.Id, dto.CreatedAt, dto.Name, dto.RNC,  dto.Email, dto.Phone, dto.Line1, dto.Line2, dto.IsActive, dto.Logo);
            await _writeRepository.CreateAsync(entity);
        }
        else
        {
            entity = await GetCompanyByIdAsync(dto.Id);
            entity.Update(dto.Name, dto.RNC,  dto.Email, dto.Phone, dto.Line1, dto.Line2, dto.IsActive, dto.Logo);
            await _writeRepository.UpdateAsync(entity);
        }
        return entity.Id;
    }
    #endregion
}
