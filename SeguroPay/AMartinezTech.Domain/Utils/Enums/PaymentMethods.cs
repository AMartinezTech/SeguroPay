using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.Enums;

public enum PaymentMethods
{
    [Display(Name = "Efectivo")]
    Cash,

    [Display(Name = "Transferencia")]
    Transfer,

    [Display(Name = "Tarjeta")]
    DebitCard,

}
