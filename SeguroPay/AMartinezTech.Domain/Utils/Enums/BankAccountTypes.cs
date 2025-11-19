using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.Enums;

public enum BankAccountTypes
{
    [Display(Name = "Corriente")]
    Current,

    [Display(Name = "Ahorro")]
    Saving
}

public enum BankAccountMovementTypes
{
    [Display(Name = "Depósito (+)")]
    Deposit,

    [Display(Name = "Cheques (-)")]
    Check,

    [Display(Name = "Débito (-)")]
    Debit,

    [Display(Name = "Crédito (+)")]
    Credit,

    [Display(Name = "Retiros por tranferencia (-)")]
    TransferWithdrawals,

    [Display(Name = "Ingresos por tranferencia (+)")]
    TransferIncome,
}