using System.Text;
using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastructure.Data.Specifications;
/// <summary>
/// Crea una especificación SQL dinámica con soporte para filtros exactos (AND),
/// búsqueda global (OR con LIKE) y rangos de fechas (BETWEEN).
/// </summary>
/// <param name="filters">Diccionario de filtros exactos (usa AND)</param> 
/// <param name="search">Diccionario de campos y valores para búsqueda general con LIKE (usa OR)</param>
/// <param name="dateRanges">Diccionario de campos de fecha con la sentencia BETWEEN)</param>
public class SqlFilterSpecification(
    Dictionary<string, object?>? filters = null,
    Dictionary<string, object?>? search = null,  
    Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null
    )
{
    private readonly Dictionary<string, object?>? _filters = filters;
    private readonly Dictionary<string, object?>? _globalSearch = search; 
    private readonly Dictionary<string, (DateTime? start, DateTime? end)>? _dateRanges = dateRanges;

    public string BuildCondition(SqlCommand cmd)
    {
        var sb = new StringBuilder("WHERE 1=1");

        
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

        
        // 🔹 Filtros por rango de fechas (BETWEEN)
        if (_dateRanges is { Count: > 0 })
        {
            foreach (var kvp in _dateRanges)
            {
                var (start, end) = kvp.Value;
                if (start.HasValue || end.HasValue)
                {
                    // Campo original con alias, por ejemplo "i.created_at"
                    string fieldName = kvp.Key;

                    // Nombre de parámetro limpio (sin puntos)
                    string safeParamName = fieldName.Replace(".", "_");

                    if (start.HasValue && end.HasValue)
                    {
                        string paramStart = $"@{safeParamName}_start";
                        string paramEnd = $"@{safeParamName}_end";
                        sb.Append($" AND {fieldName} BETWEEN {paramStart} AND {paramEnd}");
                        cmd.Parameters.AddWithValue(paramStart, start.Value);
                        cmd.Parameters.AddWithValue(paramEnd, end.Value);
                    }
                    else if (start.HasValue)
                    {
                        string paramStart = $"@{safeParamName}_start";
                        sb.Append($" AND {fieldName} >= {paramStart}");
                        cmd.Parameters.AddWithValue(paramStart, start.Value);
                    }
                    else if (end.HasValue)
                    {
                        string paramEnd = $"@{safeParamName}_end";
                        sb.Append($" AND {fieldName} <= {paramEnd}");
                        cmd.Parameters.AddWithValue(paramEnd, end.Value);
                    }
                }
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
