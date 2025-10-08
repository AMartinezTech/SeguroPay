using System.ComponentModel;

namespace AMartinezTech.WinForms.Client.Utils;

internal class UpdatingMemoryData
{
    public static BindingList<ClientViewModel> Excecute(ClientViewModel dto, BindingList<ClientViewModel> itemList)
    {
        var item = itemList.FirstOrDefault(x => x.Id == dto.Id);

        if (item != null)
        {
            // Si el elemento existe, actualizamos los valores
            item.Id = dto.Id;
            item.DocIdentity = dto.DocIdentity;
            item.FirstName = dto.FirstName;
            item.LastName = dto.LastName;
            item.Phone = dto.Phone;
            item.Email = dto.Email;
            item.ContactName = dto.ContactName;
            item.ContactPhone = dto.ContactPhone;
            item.IsActived = dto.IsActived;
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
