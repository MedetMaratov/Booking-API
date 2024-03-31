using Booking_API.DTO.Amenity;
using FluentResults;

namespace Booking_API.Interfaces;

public interface IAmenityService
{
    Task<Result<Guid>> CreateAsync(CreateAmenityDto createAmenityDto, CancellationToken ct);
    Task<Result<Guid>> UpdateAsync(UpdateAmenityDto updateAmenityDto, CancellationToken ct);
    Task<Result<Guid>> DeleteAsync(Guid id, CancellationToken ct);
    Task<Result<IEnumerable<ResponseAmenityDto>>> GetAllAsync(CancellationToken ct);
}