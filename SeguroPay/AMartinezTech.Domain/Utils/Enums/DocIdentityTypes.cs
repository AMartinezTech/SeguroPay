using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.Enums;

public enum DocIdentityTypes
{
    [Display(Name = "Cédula")] 
    ID,

    [Display(Name = "RNC")] 
    RNC,

    [Display(Name = "Pasaporte")]
    Passport
}
