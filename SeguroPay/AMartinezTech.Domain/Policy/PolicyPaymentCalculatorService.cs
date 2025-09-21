

using AMartinezTech.Domain.Utils.Enums;

namespace AMartinezTech.Domain.Policy;

public class PolicyPaymentCalculatorService
{
    public static IReadOnlyCollection<PendingPayment> GetPendingPayments(
            PolicyEntity policy,
            IReadOnlyCollection<PolicyPaymentEntity> paymentsMade,
            DateTime currentDate)
    {
        var pendientes = new List<PendingPayment>();

        // Si no hay pagos realizados, el cálculo arranca desde la fecha de creación
        var ultimaFechaPago = paymentsMade.Count != 0
            ? paymentsMade.Max(p => p.Date)
            : policy.CreatedAt;

        // Avanzamos desde la fecha del último pago hasta la fecha actual
        var fechaSiguientePago = GetNextPaymentDate(policy, ultimaFechaPago);

        while (fechaSiguientePago <= currentDate)
        {
            pendientes.Add(new PendingPayment(
                policy.Id,
                fechaSiguientePago,
                policy.Amount
            ));

            fechaSiguientePago = GetNextPaymentDate(policy, fechaSiguientePago);
        }

        return pendientes;
    }

    private static DateTime GetNextPaymentDate(PolicyEntity policy, DateTime ultimaFechaPago)
    {
        var frecuency = policy.PayFrencuency.Type; 

        return frecuency switch
        {
            PolicyPayFrencuency.Mensual => ultimaFechaPago.AddMonths(1).WithDay(policy.PayDay.Value),
            PolicyPayFrencuency.Trimestral => ultimaFechaPago.AddMonths(3).WithDay(policy.PayDay.Value),
            PolicyPayFrencuency.Semestral => ultimaFechaPago.AddMonths(6).WithDay(policy.PayDay.Value),
            PolicyPayFrencuency.Anual => ultimaFechaPago.AddYears(1).WithDay(policy.PayDay.Value),
            _ => throw new InvalidOperationException("Frecuencia no soportada")
        };
    }
}

public record PendingPayment(Guid PolicyId, DateTime PaymentDate, decimal Amount);

// Extensión para fijar el día del mes correcto
public static class DateTimeExtensions
{
    public static DateTime WithDay(this DateTime fecha, int day)
    {
        var ultimoDiaMes = DateTime.DaysInMonth(fecha.Year, fecha.Month);
        var dia = Math.Min(day, ultimoDiaMes);
        return new DateTime(fecha.Year, fecha.Month, dia);
    }
}

