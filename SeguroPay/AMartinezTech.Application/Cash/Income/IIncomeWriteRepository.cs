using AMartinezTech.Domain.Cash.Income;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Cash.Income;

public interface IIncomeWriteRepository : ICreate<IncomeEntity>, IUpdate<IncomeEntity>, IDelete<Guid>;
