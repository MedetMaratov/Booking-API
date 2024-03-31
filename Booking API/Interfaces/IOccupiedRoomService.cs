using Booking_API.DTO.OccupiedRoom;
using Booking_API.Models;
using FluentResults;

namespace Booking_API.Interfaces;

public interface IOccupiedRoomService
{
    OccupiedRoom Create(CreateOccupiedRoomDto occupiedRoomDto, CancellationToken ct);
    Task<Result<Guid>> SetCheckInAsync(Guid roomId, CancellationToken ct);
    Task<Result<Guid>> SetCheckOutAsync(Guid roomId, CancellationToken ct);
}