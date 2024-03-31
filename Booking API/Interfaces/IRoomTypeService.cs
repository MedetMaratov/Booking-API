using Booking_API.DTO.RoomType;
using FluentResults;

namespace Booking_API.Interfaces;

public interface IRoomTypeService
{
    Task<Result<Guid>> CreateAsync(CreateRoomTypeDto roomTypeDto, CancellationToken ct);
    Task<Result<Guid>> UpdateAsync(UpdateRoomTypeDto roomType, CancellationToken ct);
    Task<Result<Guid>> DeleteAsync(Guid roomId, CancellationToken ct);
    Task<Result<IEnumerable<ResponseRoomTypeDto>>> GetAllRoomTypesAsync(CancellationToken ct);
}