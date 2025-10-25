using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Enums;

namespace AMartinezTech.Domain.Cash.Income;

internal static class IncomeEnumValidator
{
    internal static (IncomeTypes IncomeTypes, PaymentMethods PaymentMethod, IncomeMadeIn IncomeMadeIn)
        
        
        ValidateEnums(string incomeTypes, string incomeMadeIn, string paymentMethod) {
        var _incomeTypes = EnumValidator.ParseEnum<IncomeTypes>(incomeTypes, nameof(IncomeTypes));
        var _paymentMethod = EnumValidator.ParseEnum<PaymentMethods>(paymentMethod, nameof(PaymentMethods));
        var _incomeMadeIn = EnumValidator.ParseEnum<IncomeMadeIn>(incomeMadeIn, nameof(IncomeMadeIn));

        return (_incomeTypes, _paymentMethod, _incomeMadeIn);
        }

    
}
