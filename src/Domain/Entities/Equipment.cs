using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Equipment :BaseEntity<Guid>
{
    public string Name {get; private set;}
    public EquipmentType Type {get; private set;}   

    public Equipment(string name, EquipmentType type)
    {
        if(string.IsNullOrWhiteSpace(name))
        throw new ArgumentException("Equipment name cannot be empty.", nameof(name));   
        Name = name;
        Type=type;
    }

    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException(
                "Equipment name cannot be empty.",
        nameof(newName));
        Name = newName;
    }

}