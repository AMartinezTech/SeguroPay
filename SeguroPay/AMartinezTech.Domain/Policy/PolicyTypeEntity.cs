using AMartinezTech.Domain.Utils;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Policy;

public class PolicyTypeEntity
{
     
    public Guid Id { get; private set; }
    public ValuePolicyTypeName Name { get; private set; }
    public bool IsActived { get; private set; } 
    public ValueGuid EnsuranceId { get; private set; }

    private PolicyTypeEntity(Guid id, ValuePolicyTypeName name, bool isActived, ValueGuid ensuranceId)
    {
        Id = id;
        Name = name;
        IsActived = isActived;
        EnsuranceId = ensuranceId;
    }

    public static PolicyTypeEntity Create(Guid id, string name, bool isActived, Guid ensuranceId)
    {
        id = CreateGuid.EnsureId(id);
        return new PolicyTypeEntity(id, ValuePolicyTypeName.Create(name), isActived, ValueGuid.Create(ensuranceId,"seguro"));
    }
}
