using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.Enums;

public enum PolicyTypes
{
    [Display(Name = "Póliza de Salud")]
    HealthPolicy,

    [Display(Name = "Póliza de Vida")]
    LifePolicy,

    [Display(Name = "Póliza General")]
    GeneralPolicy,
}
