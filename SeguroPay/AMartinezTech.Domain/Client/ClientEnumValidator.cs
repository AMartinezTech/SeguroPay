using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Enums;

namespace AMartinezTech.Domain.Client;

internal static class ClientEnumValidator
{
    internal static (DocIdentityTypes DocIdentityTypes, ClientTypes ClientTypes)
            ValidateEnums(string docIdentityTypes, string clientTypes)
    {
        var _docIdentityTypes = EnumValidator.ParseEnum<DocIdentityTypes>(docIdentityTypes, nameof(DocIdentityTypes));
        var _clientTypes = EnumValidator.ParseEnum<ClientTypes>(clientTypes, nameof(ClientTypes));
        

        return (_docIdentityTypes, _clientTypes);
    }
}
