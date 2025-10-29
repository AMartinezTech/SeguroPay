using AMartinezTech.Domain.Setting.Company;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Setting.Company;

public interface ICompanyWriteRepository : ICreate<CompanyEntity>, IUpdate<CompanyEntity>;

