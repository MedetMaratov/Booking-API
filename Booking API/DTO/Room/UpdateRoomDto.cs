namespace Booking_API.DTO.Room;

public class UpdateRoomDto
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public bool IsDisabled { get; set; }
    public Models.RoomType Type { get; set; }
}