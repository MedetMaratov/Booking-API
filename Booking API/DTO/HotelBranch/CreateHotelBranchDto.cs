using Booking_API.Models;

namespace Booking_API.DTO.HotelBranch;

public class CreateHotelBranchDto
{
    public string Name { get; set; }
    public Location Location { get; set; }
}