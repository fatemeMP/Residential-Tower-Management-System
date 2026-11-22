

namespace Domain.Common;

public abstract class AudithBaseEntiy<TId> : BaseEntity<TId>
{
    public DateTime? UpdateAt {get; private set; }
    public void MarkAsUpdated()
    {
        UpdateAt = DateTime.UtcNow;
    }
}

