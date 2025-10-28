using AMartinezTech.Application.Reports.Policies.Dtos;
using AMartinezTech.Domain.Utils.Enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AMartinezTech.Application.Reports.Policies;

public class PoplicySummaryByStatusReport
{ 

    public IReadOnlyList<PolicySummaryByStatus> Summary { get; }

    public int ActivePendingCount { get; }
    public int ActiveOnTimeCount { get; }

    public decimal ActivePendingPercentage { get; }
    public decimal ActiveOnTimePercentage { get; }

    public PoplicySummaryByStatusReport(IEnumerable<PolicyStatusProjection> policies, DateTime serverNow)
    {
        if (policies == null || !policies.Any())
        {
            Summary = [];
            return;
        }

        var totalPolicies = policies.Count();

        var grouped = policies
            .GroupBy(p => p.Status)
            .Select(g =>
            {
                var total = g.Count();
                var percentage = Math.Round(((decimal)total / totalPolicies) * 100, 2);
                // Convertir string (g.Key) al enum PolicyStatusType
                if (Enum.TryParse<PolicyStatus>(g.Key, out var enumValue))
                {
                    return new PolicySummaryByStatus
                    {
                        Status = GetDisplayName(enumValue),
                        Total = total,
                        Percentage = percentage
                    };
                }

                // Si no se pudo convertir, usa el valor original
                return new PolicySummaryByStatus
                {
                    Status = g.Key,
                    Total = total,
                    Percentage = percentage
                };
            })
            .OrderByDescending(r => r.Total)
            .ToList();

        Summary = grouped;

        // === Cálculos adicionales (solo para pólizas activas)
        var activePolicies = policies.Where(p => p.Status == PolicyStatus.Active.ToString()).ToList();
        var totalActive = activePolicies.Count;

        if (totalActive > 0)
        {
            ActivePendingCount = activePolicies.Count(p => p.GetPendingPayment(serverNow) == "Pendiente");
            ActiveOnTimeCount = activePolicies.Count(p => p.GetPendingPayment(serverNow) == "Al día");

            ActivePendingPercentage = Math.Round((decimal)ActivePendingCount / totalActive * 100, 2);
            ActiveOnTimePercentage = Math.Round((decimal)ActiveOnTimeCount / totalActive * 100, 2);
        }

    }

    private static string GetDisplayName(Enum value)
    {
        return value.GetType()
                    .GetField(value.ToString())?
                    .GetCustomAttribute<DisplayAttribute>()?
                    .GetName()
                ?? value.ToString();
    }
}
