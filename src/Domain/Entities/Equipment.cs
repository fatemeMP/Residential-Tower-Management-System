using Domain.Common;
using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Entities;

public class Equipment :BaseEntity<Guid>
{
    public string Name {get; private set;}
    public EquipmentType Type {get; private set;}   

    public ICollection<EquipmentMeasurement> Measurements {get; private set;} = new List<EquipmentMeasurement>();

    public Equipment(string name, EquipmentType type)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        Name = name;
        Type=type;
    }

    public void Rename(string newName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(newName, nameof(newName));
        Name = newName;
    }

    public void AddMeasurment(EquipmentMeasurement measurement)
    {
        ArgumentNullException.ThrowIfNull(measurement, nameof(measurement));
        Measurements.Add(measurement);
    }

}