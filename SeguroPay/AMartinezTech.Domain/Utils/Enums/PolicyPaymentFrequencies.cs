using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.Enums;

public enum PolicyPaymentFrequencies
{
    [Display(Name = "Mensual")]
    Monthly,

    [Display(Name = "Trimestral")]
    Quarterly, 

    [Display(Name = "Semestral")]
    Semiannual, 

    [Display(Name = "Anual")] 
    Annual
}
