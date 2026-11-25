using Application.Equipments.Abstractions;
using Domain.Entities;

namespace Application.Equipments.Commands;

public sealed record PollEquipmentStatusCommand(Guid EquipmentId)
{
    public sealed class Handler
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEnumerable<IEquipmentClient> _equipmentClients;

        public Handler(
            IEquipmentRepository equipmentRepository,
            IEnumerable<IEquipmentClient> equipmentClients)
        {
            ArgumentNullException.ThrowIfNull(equipmentRepository);
            ArgumentNullException.ThrowIfNull(equipmentClients);

            _equipmentRepository = equipmentRepository;
            _equipmentClients = equipmentClients;
        }

        public async Task HandleAsync(
            PollEquipmentStatusCommand command,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(command);

            var equipment = await _equipmentRepository.GetByIdAsync(command.EquipmentId, cancellationToken)
                ?? throw new KeyNotFoundException($"Equipment '{command.EquipmentId}' was not found.");

            var client = _equipmentClients.FirstOrDefault(c => c.SupportedType == equipment.Type)
                ?? throw new InvalidOperationException($"No equipment client registered for type '{equipment.Type}'.");

            var dto = await client.GetMeasurementAsync(equipment, cancellationToken);

            var measurement = new EquipmentMeasurement(
                equipment.Id,
                dto.Status,
                dto.PowerConsumption,
                dto.MeasuredAt);

            equipment.ApplyMeasurement(measurement);

            await _equipmentRepository.SaveMeasurementAsync(equipment, measurement, cancellationToken);
        }
    }
}
