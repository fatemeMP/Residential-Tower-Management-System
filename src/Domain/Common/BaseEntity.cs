
namespace Domain.Common;


public abstract class BaseEntity<TId> : IEntity
{
    public TId Id {get; private set; } = default!;

    public DateTime CreatedAt {get; private set; } 
    protected BaseEntity()
    {
        CreatedAt = DateTime.UtcNow;
    }
}


