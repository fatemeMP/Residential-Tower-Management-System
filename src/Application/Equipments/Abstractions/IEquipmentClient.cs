
using Application.Equipments.DTOs;
using Domain.Entities;
using Domain.Enums;

namespace Application.Equipments.Abstractions;

public interface IEquipmentClient
{
    EquipmentType SupportedType { get; }
    Task<EquipmentMeasurementDto> GetMeasurementAsync(Equipment equipment, CancellationToken cancellationToken = default);
}