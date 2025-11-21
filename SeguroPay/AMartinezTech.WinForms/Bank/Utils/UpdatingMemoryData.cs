using AMartinezTech.Application.Bank;
using System.ComponentModel;

namespace AMartinezTech.WinForms.Bank.Utils;

internal class UpdatingMemoryData
{
    public static BindingList<BankAccountDto> Excecute(BankAccountDto dto, BindingList<BankAccountDto> itemList)
    {
        var item = itemList.FirstOrDefault(x => x.Id == dto.Id);

        if (item != null)
        {
            // Si el elemento existe, actualizamos los valores
            item.Id = dto.Id;
            item.Name = dto.Name;
            item.CreatedAt = dto.CreatedAt;
            item.Number = dto.Number;
            item.Type = dto.Type;
            item.ContactName = dto.ContactName;
            item.ContactPhone = dto.ContactPhone;
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
