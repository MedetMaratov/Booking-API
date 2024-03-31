using Booking_API.DTO.Reservation;
using FluentResults;

namespace Booking_API.Interfaces;

public interface IReservationService
{
    Task<Result<Guid>> ReserveAsync(CreateReservationDto createReservationDto, CancellationToken ct);
    Task<Result<IEnumerable<ResponseReservationDto>>> GetAllAsync(CancellationToken ct);
}