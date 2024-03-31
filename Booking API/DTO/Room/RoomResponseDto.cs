namespace Booking_API.DTO.Room;

public class RoomResponseDto
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public Models.RoomType Type { get; set; }
    public bool IsDisabled { get; set; }
}