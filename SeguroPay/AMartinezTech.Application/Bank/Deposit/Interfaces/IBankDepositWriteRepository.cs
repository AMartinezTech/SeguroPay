using AMartinezTech.Domain.Bank.Deposit;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Bank.Deposit.Interfaces;

public interface IBankDepositWriteRepository : ICreate<BankDepositEntity>, IUpdate<BankDepositEntity>, IDelete<Guid>;
