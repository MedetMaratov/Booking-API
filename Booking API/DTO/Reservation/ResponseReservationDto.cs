using Booking_API.Enums;

namespace Booking_API.DTO.Reservation;

public class ResponseReservationDto
{
    public Guid Id { get; set; }
    public DateTime DateIn { get; set; }
    public DateTime DateOut { get; set; }
    public ReservationMethod MadeBy { get; set; }
    public ReservationStatus Status { get; set; }
    public Guid HotelBranchId { get; set; }
    public Models.HotelBranch HotelBranch { get; set; }
    public Guid ReservationCreatorId { get; set; }
}