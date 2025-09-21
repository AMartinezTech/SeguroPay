namespace AMartinezTech.Domain.Utils;

public class CreateGuid
{
    public static Guid EnsureId(Guid id)
    {
        return id == Guid.Empty ? Guid.NewGuid() : id;
    }
}
