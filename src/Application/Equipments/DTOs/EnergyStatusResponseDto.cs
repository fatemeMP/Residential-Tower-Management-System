using System.Text.Json.Serialization;

namespace Application.Equipments.DTOs;

public sealed record EnergyStatusResponseDto(
    [property: JsonPropertyName("timestamp")] DateTime Timestamp,
    [property: JsonPropertyName("equipment")] IReadOnlyList<EquipmentStatusDto> Equipment);
