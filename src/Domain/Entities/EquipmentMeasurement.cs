using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class EquipmentMeasurement :BaseEntity<Guid>
{
    public Guid EquipmentId {get; private set;}
    public EquipmentStatus Status {get; private set;}
    public decimal PowerConsumption {get; private set;}
    public DateTime MeasuredAt { get; private set; }

    public EquipmentMeasurement(
        Guid equipmentId,
        EquipmentStatus status,
        decimal powerConsumption,
        DateTime measuredAt)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(equipmentId, Guid.Empty, nameof(equipmentId));
        ArgumentOutOfRangeException.ThrowIfNegative(powerConsumption, nameof(powerConsumption));
        ArgumentOutOfRangeException.ThrowIfEqual(measuredAt, DateTime.MinValue, nameof(measuredAt));

        Id = Guid.NewGuid();
        EquipmentId = equipmentId;
        Status = status;
        PowerConsumption = powerConsumption;
        MeasuredAt = measuredAt;
    }
}