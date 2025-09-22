using AMartinezTech.Domain.Insurance;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Insurance.Interfaces;

public interface IInsuranceWriteRepository : ICreate<InsuranceEntity>, IUpdate<InsuranceEntity>;
