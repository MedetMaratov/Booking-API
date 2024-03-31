using Booking_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking_API.DataAccess.EntityConfigs;

public class HotelBranchEntityTypeConfig : IEntityTypeConfiguration<HotelBranch>
{
    public void Configure(EntityTypeBuilder<HotelBranch> builder)
    {
        builder.Property(hb => hb.Name).IsRequired();
        builder.Property(hb => hb.Name).HasMaxLength(100);
    }
}