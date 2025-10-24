using AMartinezTech.Application.Reports.Policies.Dtos;
using AMartinezTech.Domain.Utils.Enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AMartinezTech.Application.Reports.Policies;

public class PoplicySummaryByStatusReport
{ 

    public IReadOnlyList<PolicySummaryByStatus> Summary { get; }

    public PoplicySummaryByStatusReport(IEnumerable<PolicyStatusProjection> policies)
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
