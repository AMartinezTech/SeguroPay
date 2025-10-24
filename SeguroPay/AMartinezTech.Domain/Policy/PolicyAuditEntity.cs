namespace AMartinezTech.Domain.Policy;


public class PolicyAuditEntity
{
    public Guid Id { get; private set; }
    public Guid PolicyId { get; private set; }
    public string? PreviousStatus { get; private set; }
    public string NewStatus { get; private set; }
    public Guid ActionBy { get; private set; }
    public Guid AuthorizedBy { get; private set; }
    public DateTime ActionDate { get; private set; }
    public string? Comments { get; private set; }

    private PolicyAuditEntity() { } // EF / mappers

    public PolicyAuditEntity(Guid policyId, string? previousStatus, string newStatus,
                             Guid actionBy, Guid authorizedBy, string? comments = null)
    {
        ValidateStatusTransition(previousStatus, newStatus);
        ValidateUserRoles(actionBy, authorizedBy);

        Id = Guid.NewGuid();
        PolicyId = policyId;
        PreviousStatus = previousStatus;
        NewStatus = newStatus;
        ActionBy = actionBy;
        AuthorizedBy = authorizedBy;
        ActionDate = DateTime.UtcNow;
        Comments = comments;
    }

    private void ValidateStatusTransition(string? previous, string next)
    {
        if (string.IsNullOrWhiteSpace(next))
            throw new InvalidOperationException("El nuevo estado no puede estar vacío.");

        var validStatuses = new[] { "Active", "Suspended", "Canceled" };

        if (!validStatuses.Contains(next))
            throw new InvalidOperationException($"Estado '{next}' no es válido.");

        // Reglas de transición
        if (previous == "Canceled" && next != "Active")
            throw new InvalidOperationException("Una póliza cancelada solo puede reactivarse.");

        if (previous == "Suspended" && next == "Suspended")
            throw new InvalidOperationException("No se puede suspender una póliza ya suspendida.");
    }

    private void ValidateUserRoles(Guid actionBy, Guid authorizedBy)
    {
        if (actionBy == Guid.Empty || authorizedBy == Guid.Empty)
            throw new InvalidOperationException("Debe especificar los usuarios que ejecutan y autorizan.");

        if (actionBy == authorizedBy)
            throw new InvalidOperationException("El usuario que autoriza no puede ser el mismo que ejecuta la acción.");
    }
}
