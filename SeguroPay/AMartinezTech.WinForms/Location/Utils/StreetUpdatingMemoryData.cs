using AMartinezTech.Application.Location.Street; 
using System.ComponentModel;

namespace AMartinezTech.WinForms.Location.Utils;

internal class StreetUpdatingMemoryData
{
    public static BindingList<StreetDto> Excecute(StreetDto dto, BindingList<StreetDto> itemList)
    {
        var item = itemList.FirstOrDefault(x => x.Id == dto.Id);

        if (item != null)
        {
            // Si el elemento existe, actualizamos los valores
            item.Id = dto.Id;
           item.Name = dto.Name;
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
