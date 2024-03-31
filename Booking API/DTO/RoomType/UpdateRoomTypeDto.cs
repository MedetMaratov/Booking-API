namespace Booking_API.DTO.RoomType;

public class UpdateRoomTypeDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public int MaxCapacity { get; set; }
    public decimal NightlyRate { get; set; }
    public ICollection<Models.Amenity> Amenities { get; set; } = new List<Models.Amenity>();
}