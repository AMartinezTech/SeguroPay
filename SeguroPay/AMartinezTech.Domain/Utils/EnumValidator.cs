using AMartinezTech.Domain.Utils.Exception;

 
namespace AMartinezTech.Domain.Utils;

public static class EnumValidator
{
    /// <summary>
    /// Valida y convierte un valor string a un Enum del tipo especificado.
    /// </summary>
    public static TEnum ParseEnum<TEnum>(string value, string fieldName)
        where TEnum : struct, Enum
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new System.Exception($"El campo '{fieldName}' no puede estar vacío.");

        if (!Enum.TryParse(value, true, out TEnum result))
            throw new System.Exception($"{ErrorMessages.Get(ErrorType.InvalidType)} - {fieldName}");

        return result;
    }
}