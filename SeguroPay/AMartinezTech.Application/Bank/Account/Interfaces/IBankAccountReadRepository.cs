using AMartinezTech.Domain.Bank.Account;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Bank.Account.Interfaces;

public interface IBankAccountReadRepository : IPagination<BankAccountEntity>;
