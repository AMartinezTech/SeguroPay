using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.Enums;

public enum BankAccountTypes
{
    [Display(Name = "Corriente")]
    Current,

    [Display(Name = "Ahorro")]
    Saving
}
