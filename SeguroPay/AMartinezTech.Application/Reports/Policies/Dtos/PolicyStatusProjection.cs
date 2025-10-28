namespace AMartinezTech.Application.Reports.Policies.Dtos;

public class PolicyStatusProjection
{
    public string Status { get; set; } = string.Empty; 
    public DateTime? LastPayment { get; set; }


    // Nueva propiedad para evaluar pendiente según fecha del servidor
    public string GetPendingPayment(DateTime serverNow)
    {
        if (LastPayment == null)
            return "Pendiente";

        // Si el último pago fue en un mes anterior al actual o en un año anterior
        if (LastPayment.Value.Year < serverNow.Year ||
            (LastPayment.Value.Year == serverNow.Year && LastPayment.Value.Month < serverNow.Month))
        {
            return "Pendiente";
        }

        // Si el último pago es del mes actual
        return "Al día";
    }
}
