using AMartinezTech.Application.Insurance; 
using System.ComponentModel;

namespace AMartinezTech.WinForms.Insurance.Utils;

internal class UpdatingMemoryData
{
    public static BindingList<InsuranceDto> Excecute(InsuranceDto dto, BindingList<InsuranceDto> itemList)
    {
        var item = itemList.FirstOrDefault(x => x.Id == dto.Id);

        if (item != null)
        {
            // Si el elemento existe, actualizamos los valores
            item.Id = dto.Id;
            item.Name = dto.Name;
            item.Address = dto.Address;
            item.Email = dto.Email;
            item.Phone = dto.Phone;
            item.ContactPhone = dto.ContactPhone;
            item.ContactName = dto.ContactName;
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
