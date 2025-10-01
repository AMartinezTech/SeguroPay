using System.ComponentModel;

namespace AMartinezTech.WinForms.Settings.User.Utils;

internal class UpdatingMemoryData
{
    public static BindingList<UserViewModel> Excecute(UserViewModel dto, BindingList<UserViewModel> itemList)
    {
        var item = itemList.FirstOrDefault(x => x.Id == dto.Id);

        if (item != null)
        {
            // Si el elemento existe, actualizamos los valores
            item.Id = dto.Id;
            item.Email = dto.Email;
            item.FullName = dto.FullName;
            item.Phone = dto.Phone;
            item.Rol = dto.Rol;
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
