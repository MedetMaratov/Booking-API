using Booking_API.DataAccess;
using Booking_API.DTO.OccupiedRoom;
using Booking_API.Enums;
using Booking_API.Interfaces;
using Booking_API.Models;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace Booking_API.Services;

public class OccupiedRoomService : IOccupiedRoomService
{
    private readonly AppDbContext _dbContext;
    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<OccupiedRoomService> _logger;
    
    public OccupiedRoomService(AppDbContext dbContext, IDistributedCache distributedCache, ILogger<OccupiedRoomService> logger)
    {
        _dbContext = dbContext;
        _distributedCache = distributedCache;
        _logger = logger;
    }

    public OccupiedRoom Create(CreateOccupiedRoomDto occupiedRoomDto, CancellationToken ct)
    {
        var occupiedRoom = new OccupiedRoom()
        {
            Id = Guid.NewGuid(),
            RoomId = occupiedRoomDto.RoomId,
            ReservationId = occupiedRoomDto.ReservationId,
            CheckIn = null,
            CheckOut = null,
            Status = OccupiedRoomStatus.Expected,
        };
        
        return occupiedRoom;
    }

    public async Task<Result<Guid>> SetCheckInAsync(Guid roomId, CancellationToken ct)
    {
        var room = await _dbContext
            .OccupiedRooms
            .SingleOrDefaultAsync(r => r.Id == roomId, ct);

        if (room == null)
            return Result.Fail("Room not find");

        room.CheckIn = DateTime.Now;
        room.Status = OccupiedRoomStatus.Reside;

        _dbContext.Update(room);
        await _dbContext.SaveChangesAsync(ct);

        _logger.LogInformation($"Check-In set for {nameof(OccupiedRoom)} with Id: {room.Id}");

        return Result.Ok(room.Id);
    }

    public async Task<Result<Guid>> SetCheckOutAsync(Guid roomId, CancellationToken ct)
    {
        var room = await _dbContext
            .OccupiedRooms
            .SingleOrDefaultAsync(r => r.Id == roomId, ct);

        if (room == null)
            return Result.Fail("Room not find");

        room.CheckOut = DateTime.Now;
        room.Status = OccupiedRoomStatus.Left;

        _dbContext.Update(room);
        await _dbContext.SaveChangesAsync(ct);

        _logger.LogInformation($"Check-Out set for OccupiedRoom with Id: {room.Id}");

        return Result.Ok(room.Id);
    }
}