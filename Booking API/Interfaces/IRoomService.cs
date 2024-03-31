using Booking_API.DTO.Room;
using FluentResults;

namespace Booking_API.Interfaces;

public interface IRoomService
{
    Task<Result<Guid>> CreateAsync(CreateRoomDto dto, CancellationToken ct);
    Task<Result<Guid>> UpdateAsync(UpdateRoomDto dto, CancellationToken ct);
    Task<Result> EnableRoomAsync(Guid roomId, CancellationToken ct);
    Task<Result> DisableRoomAsync(Guid roomId, CancellationToken ct);
    Task<Result<Guid>> DeleteAsync(Guid roomId, CancellationToken ct);
    Task<Result<IEnumerable<RoomResponseDto>>> GetAllAsync(CancellationToken ct);
    Task<Result<IEnumerable<RoomResponseDto>>> GetRoomsByTypeAsync(Guid roomTypeId, CancellationToken ct);
}