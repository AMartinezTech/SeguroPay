using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.Enums;

public enum IncomeMadeIn
{

    [Display(Name = "Oficina")]
    Office, 
    
    [Display(Name = "Aseguradora")] 
    Insurance, 
    
    [Display(Name = "Depósito en Banco")]
    DepositBank, 
    
    [Display(Name = "Transferencia Oficina")] 
    TranferOffice, 
    
    [Display(Name = "Transferencia Aseguradora")] 
    TransferInsurance
}
