using System.Text;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Data.Specifications;
/// <summary>
/// Crea una especificación SQL dinámica con soporte para filtros exactos (AND)
/// y búsqueda global (OR con LIKE).
/// </summary>
/// <param name="filters">Diccionario de filtros exactos (usa AND)</param>
/// <param name="isActive">Filtro opcional por estado activo/inactivo</param>
/// <param name="search">Diccionario de campos y valores para búsqueda general con LIKE (usa OR)</param>
public class SqlFilterSpecification(
    Dictionary<string, object?>? filters = null,
    Dictionary<string, object?>? search = null, 
    bool? isActive = null)
{
    private readonly Dictionary<string, object?>? _filters = filters;
    private readonly Dictionary<string, object?>? _globalSearch = search;
    private readonly bool? _isActive = isActive;

    public string BuildCondition(SqlCommand cmd)
    {
        var sb = new StringBuilder("WHERE 1=1");

        // 🔹 Filtro por estado
        if (_isActive.HasValue)
        {
            sb.Append(" AND is_active = @is_active");
            cmd.Parameters.AddWithValue("@is_active", _isActive.Value);
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
