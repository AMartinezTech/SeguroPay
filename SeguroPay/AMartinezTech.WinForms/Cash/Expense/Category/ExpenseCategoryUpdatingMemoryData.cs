using AMartinezTech.Application.Cash.Expense.Category; 
using System.ComponentModel;

namespace AMartinezTech.WinForms.Cash.Expense.Category;

internal class ExpenseCategoryUpdatingMemoryData
{
    internal static BindingList<ExpenseCategoryDto> Excecute(ExpenseCategoryDto dto, BindingList<ExpenseCategoryDto> itemList)
    {
        var item = itemList.FirstOrDefault(x => x.Id == dto.Id);

        if (item != null)
        {
            // Si el elemento existe, actualizamos los valores
            item.Id = dto.Id;
            item.Name = dto.Name;
            item.IsActive = dto.IsActive;

        }
        else
        {
            // Si el elemento no existe, lo agregamos
            itemList.Add(dto);
        }

        // Devuelvo la lista actualizada
        return itemList;
    }
}
