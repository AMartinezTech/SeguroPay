using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Enums;

namespace AMartinezTech.Domain.Policy;

internal static class PolicyEnumValidator
{
    internal static (PolicyTypes PolicyType, PolicyPaymentFrequencies PayFrequency)
            ValidateEnums(string policyTypes, string payFrequency)
    {
        var _policyType = EnumValidator.ParseEnum<PolicyTypes>(policyTypes, nameof(policyTypes));
        var _payFrequency = EnumValidator.ParseEnum<PolicyPaymentFrequencies>(payFrequency, nameof(payFrequency)); 

        return (_policyType, _payFrequency);
    }
}
