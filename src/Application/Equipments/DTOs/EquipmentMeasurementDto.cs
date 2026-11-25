using Domain.Enums;

namespace Application.Equipments.DTOs;

public sealed record EquipmentMeasurementDto(
    EquipmentStatus Status,
    decimal PowerConsumption,
    DateTime MeasuredAt);
