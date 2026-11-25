using System.Globalization;
using Application.Equipments.Abstractions;
using Application.Equipments.DTOs;
using Domain.Entities;

namespace Application.Equipments.Queries;

public sealed record GetEnergyStatusQuery
{
    public sealed class Handler
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEnergyStatusCache _energyStatusCache;

        public Handler(
            IEquipmentRepository equipmentRepository,
            IEnergyStatusCache energyStatusCache)
        {
            ArgumentNullException.ThrowIfNull(equipmentRepository);
            ArgumentNullException.ThrowIfNull(energyStatusCache);

            _equipmentRepository = equipmentRepository;
            _energyStatusCache = energyStatusCache;
        }

        public async Task<EnergyStatusResponseDto> HandleAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Equipment> equipments;

            try
            {
                equipments = await _equipmentRepository.GetAllAsync(cancellationToken);
            }
            catch (Exception) when (!cancellationToken.IsCancellationRequested)
            {
                var cachedStatus = await _energyStatusCache.GetLatestAsync(cancellationToken);
                if (cachedStatus is not null)
                {
                    return cachedStatus;
                }

                throw;
            }

            var items = equipments
                .Select(equipment => new EquipmentStatusDto(
                    equipment.Name,
                    equipment.Status.ToString().ToLowerInvariant(),
                    $"{equipment.PowerConsumption.ToString("0.##", CultureInfo.InvariantCulture)}KW"))
                .ToList();

            var response = new EnergyStatusResponseDto(DateTime.UtcNow, items);

            await _energyStatusCache.SetLatestAsync(response, cancellationToken);

            return response;
        }
    }
}
