using AMartinezTech.Application.Client.Conversation;
using System.ComponentModel;

namespace AMartinezTech.WinForms.Client.Conversations.Utils;

internal class UpdatingMemoryData
{
    public static BindingList<ClientConversationDto> Excecute(ClientConversationDto dto, BindingList<ClientConversationDto> itemList)
    {
        var item = itemList.FirstOrDefault(x => x.Id == dto.Id);

        if (item != null)
        {
            // Si el elemento existe, actualizamos los valores
            item.Id = dto.Id;
            item.ContactNumber = dto.ContactNumber;
            item.Subject = dto.Subject;
            item.Channel = dto.Channel;
            item.Message = dto.Message;
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
