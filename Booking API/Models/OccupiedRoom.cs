using Booking_API.Enums;

namespace Booking_API.Models;
public class OccupiedRoom
{
    public Guid Id { get; set; }
    public DateTime? CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }
    public OccupiedRoomStatus Status { get; set; }
    public Guid? RoomId { get; set; }
    public Room? Room { get; set; }
    public Guid ReservationId { get; set; }
    public Reservation? Reservation { get; set; }
}