using Booking_API.Interfaces;
using Booking_API.Services;

namespace Booking_API.Configures;

public static class ConfigServiceCollectionExtensions
{
    public static IServiceCollection AddDependencyGroup(this IServiceCollection services)
    {
        services.AddScoped<IRoomService, Services.RoomService>();
        services.AddScoped<IRoomTypeService, RoomTypeService>();
        services.AddScoped<IAmenityService, AmenityService>();
        services.AddScoped<IOccupiedRoomService, OccupiedRoomService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IHotelBranchService, HotelBranchService>();
        services.AddScoped<IRoomFinderService, RoomFinderService>();

        return services;
    }
}