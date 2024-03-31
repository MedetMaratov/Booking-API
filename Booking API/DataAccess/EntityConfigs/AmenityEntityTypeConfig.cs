using Booking_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking_API.DataAccess.EntityConfigs;

public class AmenityEntityTypeConfig : IEntityTypeConfiguration<Amenity>
{
    public void Configure(EntityTypeBuilder<Amenity> builder)
    {
        builder.Property(a => a.Title).IsRequired();
        builder.Property(a => a.Title).HasMaxLength(100);
        builder.Property(a => a.Description).IsRequired();
    }
}