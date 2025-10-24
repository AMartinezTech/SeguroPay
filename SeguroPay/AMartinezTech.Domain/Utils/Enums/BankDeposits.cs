using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.Enums;

public enum BankDeposits
{
    [Display(Name = "Efectivo")]
    Cash,
    
    [Display(Name = "Cheque")]
    Check,
    
    [Display(Name = "Transferencia")]
    Transfer,
    
    [Display(Name = "Tarjeta")]
    Card
}
