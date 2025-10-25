using AMartinezTech.Domain.Cash.Income;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Cash.Income;

public interface IIncomeReadRepository : IFilter<IncomeEntity>, IGetById<IncomeEntity,Guid>;