using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Equipment : AudithBaseEntiy<Guid>
{
    public string Name { get; private set; }
    public EquipmentType Type { get; private set; }
    public EquipmentStatus Status { get; private set; } = EquipmentStatus.Inactive;
    public decimal PowerConsumption { get; private set; }
    public TimeSpan PollingInterval { get; private set; }
    public DateTime? LastMeasuredAt { get; private set; }

    public Equipment(string name, EquipmentType type, TimeSpan pollingInterval)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(pollingInterval, TimeSpan.Zero, nameof(pollingInterval));

        Id = Guid.NewGuid();
        Name = name;
        Type = type;
        PollingInterval = pollingInterval;
    }

    public void Rename(string newName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(newName, nameof(newName));
        Name = newName;
        MarkAsUpdated();
    }

    public void UpdatePollingInterval(TimeSpan pollingInterval)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(pollingInterval, TimeSpan.Zero, nameof(pollingInterval));
        PollingInterval = pollingInterval;
        MarkAsUpdated();
    }

    public void ApplyMeasurement(EquipmentMeasurement measurement)
    {
        ArgumentNullException.ThrowIfNull(measurement, nameof(measurement));

        if (measurement.EquipmentId != Id)
        {
            throw new ArgumentException("Measurement does not belong to this equipment.", nameof(measurement));
        }

        Status = measurement.Status;
        PowerConsumption = measurement.PowerConsumption;
        LastMeasuredAt = measurement.MeasuredAt;
        MarkAsUpdated();
    }
}