using AMartinezTech.Domain.Bank;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Bank;

public interface IBankAccountReadRepository : IFilter<BankAccountEntity>, IGetById<BankAccountEntity, Guid>;
