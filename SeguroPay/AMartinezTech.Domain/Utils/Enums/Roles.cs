using System.ComponentModel.DataAnnotations;

namespace AMartinezTech.Domain.Utils.Enums;

public enum Roles
{

    [Display(Name = "Administrador")]
    Administrator,

    [Display(Name = "Gestor")]
    Manager,

    [Display(Name = "Agente")]
    Agent
}
