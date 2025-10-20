using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.Enums;

public enum PolicyStatusType
{
    [Display(Name = "Activa")]
    Active,
    
    [Display(Name = "Suspendida")]
    Suspended,
    
    [Display(Name = "Cancelada")]
    Canceled,
    
    [Display(Name = "Inactiva")]
    Inactive
}
