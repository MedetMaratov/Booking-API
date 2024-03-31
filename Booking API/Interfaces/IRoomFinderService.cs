using FluentResults;
using RoomService.DTO;

namespace Booking_API.Interfaces;

public interface IRoomFinderService
{
    Task<Result<IEnumerable<Guid>>> GetRoomIdsForReservationAsync(RoomsForReserveDto roomsForReserveDto, CancellationToken ct);
}