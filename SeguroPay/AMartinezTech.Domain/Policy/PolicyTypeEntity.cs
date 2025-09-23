using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Policy;

public class PolicyTypeEntity
{
     
    public Guid Id { get; private set; }
    public ValuePolicyTypeName Name { get; private set; }
    public bool IsActived { get; private set; } 
    public ValueGuid InsuranceId { get; private set; }

    private PolicyTypeEntity(Guid id, ValuePolicyTypeName name, bool isActived, ValueGuid insuranceId)
    {
        Id = id;
        Name = name;
        IsActived = isActived;
        InsuranceId = insuranceId;
    }

    public static PolicyTypeEntity Create(Guid id, string name, bool isActived, Guid insuranceId)
    {
        id = CreateGuid.EnsureId(id);
        return new PolicyTypeEntity(id, ValuePolicyTypeName.Create(name), isActived, ValueGuid.Create(insuranceId,"seguro"));
    }
}
