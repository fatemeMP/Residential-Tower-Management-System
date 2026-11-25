using Domain.Entities;
namespace Application.Equipments.Abstractions;

public interface IEquipmentRepository
{
    Task<IReadOnlyList<Equipment>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Equipment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task SaveMeasurementAsync(
        Equipment equipment,
        EquipmentMeasurement measurement,
        CancellationToken cancellationToken = default);
}

