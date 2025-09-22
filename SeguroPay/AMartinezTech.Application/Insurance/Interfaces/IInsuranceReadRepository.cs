using AMartinezTech.Domain.Insurance;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Insurance.Interfaces;

public interface IInsuranceReadRepository : IGetById<InsuranceEntity, Guid>, IFilter<InsuranceEntity>, IPagination<InsuranceEntity>;
