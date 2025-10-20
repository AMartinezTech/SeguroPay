using AMartinezTech.Application.Policy.Type;
using System.ComponentModel;

namespace AMartinezTech.WinForms.Policy.Type;

internal class UpdatingMemoryData
{
    public static BindingList<PolicyTypeDto> Excecute(PolicyTypeDto dto, BindingList<PolicyTypeDto> itemList)
    {
        var item = itemList.FirstOrDefault(x => x.Id == dto.Id);

        if (item != null)
        {
            // Si el elemento existe, actualizamos los valores
            item.Id = dto.Id; 
            item.Name = dto.Name; 
            item.InsuranceId = dto.InsuranceId;
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
