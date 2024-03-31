using Booking_API.Enums;
using RoomService.DTO;

namespace Booking_API.DTO.Reservation;

public class CreateReservationDto
{
    public Guid ReservationCreatorId { get; set; }
    public Guid HotelBranchId { get; set; }
    public RoomsForReserveDto[] RoomsForReserveDtos { get; set; }
    public DateTime DateIn { get; set; }
    public DateTime DateOut { get; set; }
    public ReservationMethod ReservationMethod { get; set; }
}