using Booking_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking_API.DataAccess.EntityConfigs;

public class RoomEntityTypeConfig : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.Property(r => r.Number).IsRequired();
        builder.Property(r => r.Type).IsRequired();
    }
}