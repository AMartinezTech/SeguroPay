using AMartinezTech.Application.Setting.User.Interfaces;
using AMartinezTech.Application.Utils.Interfaces;

namespace AMartinezTech.Application.Cash.Income;

public class OtherIncomeAppService(IIncomeWriteRepository writeRepository, ICurrectUser currentUser, IServerTimeProvider serverTimeProvider) : BaseIncomeService(writeRepository, currentUser)
{
    private readonly IServerTimeProvider _serverTimeProvider = serverTimeProvider;
    public async Task<Guid> CreateAsync(IncomeDto dto)
    {
        var currentServerDateTime = await _serverTimeProvider.GetServerDateTimeAsync();
        // No requiere policyId ni fecha ajustada
        var entity = CreateBaseIncomeAsync(
            currentServerDateTime,
            currentServerDateTime,
            null,
            dto.ClientId,
            dto.IncomeType,
            dto.PaymentMethod,
            dto.MadeIn,
            dto.Amount,
            dto.Note);

        return await SaveIncomeAsync(entity);
    }
}
