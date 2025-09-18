namespace AMartinezTech.Core.Utils;

public class CreateGuid
{
    public static Guid EnsureId(Guid id)
    {
        return id == Guid.Empty ? Guid.NewGuid() : id;
    }
}
