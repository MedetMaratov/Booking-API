namespace Booking_API.DTO.OccupiedRoom;

public class CreateOccupiedRoomDto
{
    public Guid RoomId { get; set; }
    public Guid ReservationId { get; set; }
}