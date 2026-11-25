using System.Text.Json.Serialization;

namespace Application.Equipments.DTOs;

public sealed record EquipmentStatusDto(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("power_consumption")] string PowerConsumption);
