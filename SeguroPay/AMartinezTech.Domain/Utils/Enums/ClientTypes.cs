using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.Enums;

public enum ClientTypes
{
    [Display(Name = "Asegurados")]
    Insured, 
    [Display(Name = "Accesoría")]
    Accessory
}
