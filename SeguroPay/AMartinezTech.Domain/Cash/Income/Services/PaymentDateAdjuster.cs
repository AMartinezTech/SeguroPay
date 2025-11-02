namespace AMartinezTech.Domain.Cash.Income.Services;

public static class PaymentDateAdjuster
{
    public static DateTime AdjustToValidPaymentDate(DateTime referenceDate, int paymentDay)
    {
        var lastDayOfMonth = DateTime.DaysInMonth(referenceDate.Year, referenceDate.Month);
        var safeDay = Math.Min(paymentDay, lastDayOfMonth);

        return new DateTime(referenceDate.Year, referenceDate.Month, safeDay,
            referenceDate.Hour, referenceDate.Minute, referenceDate.Second);
    }
}