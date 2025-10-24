using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.Enums;

public enum ChannelConvertations
{
    [Display(Name = "Teléfono")] 
    Phone,

    [Display(Name = "WhatsApp")] 
    WhatsApp, 
    
    [Display(Name = "Correo")] 
    Email
}
