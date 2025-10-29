
using AMartinezTech.Domain.Utils.Enums;
using System.ComponentModel.DataAnnotations; 
using System.Reflection; 

namespace AMartinezTech.WinForms.Utils;

public static class DataGridViewEnumExtensions
{
    /// <summary>
    /// Convierte las columnas tipo enum de un DataGridView a su DisplayAttribute.
    /// </summary>
    /// <param name="grid">El DataGridView a procesar.</param>
    /// <param name="columnNames">Opcional: columnas específicas a traducir. Si es null, se intentan todas.</param>
    public static void TranslateEnumColumns(this DataGridView grid, params string[] columnNames)
    {

        foreach (DataGridViewRow row in grid.Rows)
        {
            if (row.DataBoundItem == null) continue;

            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (columnNames != null && columnNames.Length > 0 && !columnNames.Contains(col.Name))
                    continue;

                var cellValue = row.Cells[col.Name].Value;
                if (cellValue == null) continue;

                Type enumType = null;

                // Intentamos detectar tipo enum si el valor es enum
                if (cellValue.GetType().IsEnum)
                    enumType = cellValue.GetType();
                else if (cellValue is string s)
                {
                    // Intenta mapear el string al enum usando el nombre en inglés
                    enumType = col.Name switch
                    {
                        "PaymentFrequency" => typeof(PolicyPaymentFrequencies),
                        "PaymentMethod" => typeof(PaymentMethods),
                        "PolicyType" => typeof(PolicyTypes),
                        "MadeIn" => typeof(IncomeMadeIn),
                        _ => null
                    };

                    if (enumType != null && Enum.TryParse(enumType, s, out var parsed))
                        cellValue = parsed; // reemplaza string con enum
                }

                if (enumType != null && enumType.IsEnum)
                {
                    var displayName = enumType.GetField(cellValue!.ToString()!)?
                                         .GetCustomAttribute<DisplayAttribute>()?
                                         .GetName()
                                      ?? cellValue.ToString();

                    row.Cells[col.Name].Value = displayName;
                }
            }
        }
         
        

    }
}
  