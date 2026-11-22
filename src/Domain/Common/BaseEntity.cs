
namespace Domain.Common;

public abstract class BaseEntity
{
    public Guid Id {get; private set; } = Guid.NewGuid();

    public DateTime CreatedAt {get; private set; }

    public DateTime? UpdateAt {get; private set; }

    public void MarkAsCreated(DateTime utcNow)
    {
        if(CreatedAt == default)
        {
            CreatedAt = utcNow;
        }
    }

    public void MarkAsUpdated(DateTime utcNow)
    {
        UpdateAt = utcNow;
    }

}