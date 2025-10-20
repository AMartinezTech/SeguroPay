using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.Exception;
using AMartinezTech.Domain.Utils.Interfaces;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Policy;

public class PolicyTypeEntity : IAggregateRoot
{

    public Guid Id { get; private set; }
    public ValuePolicyTypeName Name { get; private set; }
    public ValueGuid InsuranceId { get; private set; }
    public bool HasMovements { get; private set; } = false;
    public bool IsActive { get; private set; }

    private PolicyTypeEntity(Guid id, ValuePolicyTypeName name, ValueGuid insuranceId, bool isActive )
    {
        Id = id;
        Name = name;
        InsuranceId = insuranceId;
        IsActive = isActive;
    }
    public static PolicyTypeEntity Create(Guid id, string name, Guid insuranceId, bool IsActive = true)
    {
        return new PolicyTypeEntity(CreateGuid.EnsureId(id),ValuePolicyTypeName.Create(name), ValueGuid.Create(insuranceId, "Insurance"), IsActive);
    }

    public void Update(string name, Guid insuranceId, bool isActive)
    {
        if (HasMovements) throw new Exception($"{ErrorMessages.Get(ErrorType.HasMomevements)}");

        Name = ValuePolicyTypeName.Create(name);
        InsuranceId = ValueGuid.Create(insuranceId,"Insurance");
        IsActive = isActive;
    }

}
