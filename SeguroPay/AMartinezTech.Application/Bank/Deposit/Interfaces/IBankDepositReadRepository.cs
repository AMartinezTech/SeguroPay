using AMartinezTech.Domain.Bank.Deposit;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Bank.Deposit.Interfaces;

public interface IBankDepositReadRepository :  IGetById<BankDepositEntity, Guid>, IFilter<BankDepositEntity>, IPagination<BankDepositEntity>;
