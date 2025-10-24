using AMartinezTech.Application.Policy.DTOs;
using System.ComponentModel;

namespace AMartinezTech.WinForms.Policy.Utils;

internal class UpdatingMemoryData
{
    public static BindingList<PolicyDto> Excecute(PolicyDto dto, BindingList<PolicyDto> itemList)
    {
        var item = itemList.FirstOrDefault(x => x.Id == dto.Id);

        if (item != null)
        {
            // Si el elemento existe, actualizamos los valores
            item.Id = dto.Id;
            item.PolicyNo = dto.PolicyNo;
            item.CreatedAt = dto.CreatedAt;
            item.PolicyType = dto.PolicyType;
            item.PaymentInstallment = dto.PaymentInstallment;
            item.PaymentMethod = dto.PaymentMethod;
            item.PaymentDay = dto.PaymentDay;
            item.InsuranceId = dto.InsuranceId;
            item.InsuranceName = dto.InsuranceName;
            item.ClientId = dto.ClientId;
            item.ClientName = dto.ClientName;
            item.Status = dto.Status;

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
