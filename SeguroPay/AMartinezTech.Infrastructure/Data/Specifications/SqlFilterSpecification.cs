using System.Text;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Data.Specifications;
/// <summary>
/// Crea una especificación SQL dinámica con soporte para filtros exactos (AND)
/// y búsqueda global (OR con LIKE).
/// </summary>
/// <param name="filters">Diccionario de filtros exactos (usa AND)</param>
/// <param name="isActived">Filtro opcional por estado activo/inactivo</param>
/// <param name="globalSearch">Diccionario de campos y valores para búsqueda general con LIKE (usa OR)</param>
public class SqlFilterSpecification(
    Dictionary<string, object?>? filters = null,
    Dictionary<string, object?>? globalSearch = null, 
    bool? isActived = null)
{
    private readonly Dictionary<string, object?>? _filters = filters;
    private readonly Dictionary<string, object?>? _globalSearch = globalSearch;
    private readonly bool? _isActived = isActived;

    public string BuildCondition(SqlCommand cmd)
    {
        var sb = new StringBuilder("WHERE 1=1");

        // 🔹 Filtro por estado
        if (_isActived.HasValue)
        {
            sb.Append(" AND is_actived = @is_actived");
            cmd.Parameters.AddWithValue("@is_actived", _isActived.Value);
        }

        // 🔹 Filtros exactos (AND)
        if (_filters is { Count: > 0 })
        {
            foreach (var kvp in _filters)
            {
                if (kvp.Value is null) continue;

                string param = $"@{kvp.Key}";
                sb.Append($" AND {kvp.Key} = {param}");
                cmd.Parameters.AddWithValue(param, kvp.Value);
            }
        }

        // 🔹 Filtros globales (OR con LIKE)
        if (_globalSearch is { Count: > 0 })
        {
            var orConditions = new List<string>();
            int index = 0;

            foreach (var kvp in _globalSearch)
            {
                if (kvp.Value is null || string.IsNullOrWhiteSpace(kvp.Value.ToString())) continue;

                string param = $"@like{index++}";
                orConditions.Add($"{kvp.Key} LIKE {param} COLLATE Latin1_General_CI_AI");
                cmd.Parameters.AddWithValue(param, $"%{kvp.Value}%");
            }

            if (orConditions.Count > 0)
                sb.Append(" AND (" + string.Join(" OR ", orConditions) + ")");
        }

        return sb.ToString();
    }
}
