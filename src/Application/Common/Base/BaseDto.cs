namespace Application.Common.Base;

public abstract record BaseDto<TId>
{
    public TId Id { get; init; } = default!;
    public DateTime CreatedAt { get; init; }
}
