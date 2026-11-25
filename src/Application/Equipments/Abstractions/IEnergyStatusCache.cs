using Application.Equipments.DTOs;

namespace Application.Equipments.Abstractions;


public interface IEnergyStatusCache
{
    Task<EnergyStatusResponseDto?> GetLatestAsync(CancellationToken cancellationToken = default);
    Task SetLatestAsync(EnergyStatusResponseDto status, CancellationToken cancellationToken = default);
}