using Booking_API.Models;

namespace Booking_API.DTO.HotelBranch;

public class ResponseHotelBranchDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Location Location { get; set; }
}