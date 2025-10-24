using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Enums;

namespace AMartinezTech.Domain.Policy;

internal static class PolicyEnumValidator
{
    internal static (PolicyTypes PolicyType, PolicyPaymentFrequencies PayFrequency, PaymentMethods PaymentMethod)
            ValidateEnums(string policyTypes, string payFrequency, string methodOfPayment)
    {
        var _policyType = EnumValidator.ParseEnum<PolicyTypes>(policyTypes, nameof(policyTypes));
        var _payFrequency = EnumValidator.ParseEnum<PolicyPaymentFrequencies>(payFrequency, nameof(payFrequency));
        var _paymentMethod = EnumValidator.ParseEnum<PaymentMethods>(methodOfPayment, nameof(methodOfPayment));

        return (_policyType, _payFrequency, _paymentMethod);
    }
}
