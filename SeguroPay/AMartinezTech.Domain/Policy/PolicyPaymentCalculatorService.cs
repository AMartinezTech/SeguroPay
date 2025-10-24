using AMartinezTech.Domain.Cash.Income;
using AMartinezTech.Domain.Utils.Enums;

namespace AMartinezTech.Domain.Policy;
public class PolicyPaymentCalculatorService
{
    public static IReadOnlyCollection<PendingPayment> GetPendingPayments(
        PolicyEntity policy,
        IReadOnlyCollection<IncomeEntity> paymentsMade,
        DateTime currentDate)
    {
        var pendientes = new List<PendingPayment>();

        // Filtramos solo los pagos de tipo Insurance
        var insurancePayments = paymentsMade
            .Where(p => p.IncomeType == IncomeTypes.Insured)
            .ToList();

        DateTime ultimaFechaPago;

        if (insurancePayments.Count == 0)
        {
            // Si no hay pagos de tipo Insurance, se toma el mes en curso
            var hoy = currentDate;
            ultimaFechaPago = new DateTime(hoy.Year, hoy.Month, policy.PaymentDay.Value);

            // Si la fecha calculada ya pasó en el mes actual, sumamos la frecuencia
            if (ultimaFechaPago < hoy)
                ultimaFechaPago = GetNextPaymentDate(policy, ultimaFechaPago.AddMonths(-1));
        }
        else
        {
            // Si hay pagos, tomamos la última fecha de pago
            ultimaFechaPago = insurancePayments.Max(p => p.CreatedAt);
        }

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
        return policy.PaymentFrequency switch
        {
            PolicyPaymentFrequencies.Monthly => ultimaFechaPago.AddMonths(1).WithDay(policy.PaymentDay.Value),
            PolicyPaymentFrequencies.Quarterly => ultimaFechaPago.AddMonths(3).WithDay(policy.PaymentDay.Value),
            PolicyPaymentFrequencies.Semiannual => ultimaFechaPago.AddMonths(6).WithDay(policy.PaymentDay.Value),
            PolicyPaymentFrequencies.Annual => ultimaFechaPago.AddYears(1).WithDay(policy.PaymentDay.Value),
            _ => throw new InvalidOperationException("Frecuencia de pago no soportada")
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

//public class PolicyPaymentCalculatorService
//{
//    public static IReadOnlyCollection<PendingPayment> GetPendingPayments(PolicyEntity policy, IReadOnlyCollection<IncomeEntity> paymentsMade,  DateTime currentDate)
//    {
//        var pendientes = new List<PendingPayment>();

//        // Si no hay pagos realizados, el cálculo arranca desde la fecha de creación
//        var ultimaFechaPago = paymentsMade.Count != 0
//            ? paymentsMade.Max(p => p.CreatedAt)
//            : policy.CreatedAt;

//        // Avanzamos desde la fecha del último pago hasta la fecha actual
//        var fechaSiguientePago = GetNextPaymentDate(policy, ultimaFechaPago);

//        while (fechaSiguientePago <= currentDate)
//        {
//            pendientes.Add(new PendingPayment(
//                policy.Id,
//                fechaSiguientePago,
//                policy.Amount
//            ));

//            fechaSiguientePago = GetNextPaymentDate(policy, fechaSiguientePago);
//        }

//        return pendientes;
//    }

//    private static DateTime GetNextPaymentDate(PolicyEntity policy, DateTime ultimaFechaPago)
//    {
//        var frecuency = policy.PaymentFrequency;

//        return frecuency switch
//        {
//            PolicyPaymentFrequencies.Monthly => ultimaFechaPago.AddMonths(1).WithDay(policy.PaymentDay.Value),
//            PolicyPaymentFrequencies.Quarterly => ultimaFechaPago.AddMonths(3).WithDay(policy.PaymentDay.Value),
//            PolicyPaymentFrequencies.Semiannual => ultimaFechaPago.AddMonths(6).WithDay(policy.PaymentDay.Value),
//            PolicyPaymentFrequencies.Annual => ultimaFechaPago.AddYears(1).WithDay(policy.PaymentDay.Value),
//            _ => throw new InvalidOperationException("Frecuencia de pago no soportada")
//        };
//    }
//}

//public record PendingPayment(Guid PolicyId, DateTime PaymentDate, decimal Amount);

//// Extensión para fijar el día del mes correcto
//public static class DateTimeExtensions
//{
//    public static DateTime WithDay(this DateTime fecha, int day)
//    {
//        var ultimoDiaMes = DateTime.DaysInMonth(fecha.Year, fecha.Month);
//        var dia = Math.Min(day, ultimoDiaMes);
//        return new DateTime(fecha.Year, fecha.Month, dia);
//    }
//}

