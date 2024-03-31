using Booking_API.DataAccess;
using Booking_API.DTO.HotelBranch;
using Booking_API.Interfaces;
using Booking_API.Models;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Booking_API.Services;

public class HotelBranchService : IHotelBranchService
{
    private readonly AppDbContext _dbContext;
    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<HotelBranchService> _logger;

    public HotelBranchService(AppDbContext dbContext, IDistributedCache distributedCache, ILogger<HotelBranchService> logger)
    {
        _dbContext = dbContext;
        _distributedCache = distributedCache;
        _logger = logger;
    }

    public async Task<Result<Guid>> CreateAsync(CreateHotelBranchDto hotelBranchDto, CancellationToken ct)
    {
        var hotelBranch = new HotelBranch()
        {
            Id = Guid.NewGuid(),
            Location = hotelBranchDto.Location,
            Name = hotelBranchDto.Name
        };

        await _dbContext.HotelBranches.AddAsync(hotelBranch, ct);
        await _dbContext.SaveChangesAsync(ct);

        _logger.LogInformation($"{nameof(HotelBranch)} created with Id: {hotelBranch.Id}");

        return Result.Ok(hotelBranch.Id);
    }

    public async Task<Result<Guid>> UpdateAsync(UpdateHotelBranchDto hotelBranchDto, CancellationToken ct)
    {
        var hotelBranchForUpdate =
            await _dbContext.HotelBranches.SingleOrDefaultAsync(hb => hb.Id == hotelBranchDto.Id, ct);

        if (hotelBranchForUpdate == null)
            return Result.Fail("Hotel branch not found");

        hotelBranchForUpdate.Location = hotelBranchDto.Location;
        hotelBranchForUpdate.Name = hotelBranchForUpdate.Name;

        _dbContext.Update(hotelBranchForUpdate);
        await _dbContext.SaveChangesAsync(ct);

        _logger.LogInformation($"{nameof(HotelBranch)} updated with Id: {hotelBranchForUpdate.Id}");

        return Result.Ok(hotelBranchForUpdate.Id);
    }

    public async Task<Result<Guid>> DeleteAsync(Guid hotelBranchId, CancellationToken ct)
    {
        var hotelBranchForDelete =
            await _dbContext.HotelBranches.SingleOrDefaultAsync(hb => hb.Id == hotelBranchId, ct);

        if (hotelBranchForDelete == null)
            return Result.Fail("Hotel branch not found");

        _dbContext.HotelBranches.Remove(hotelBranchForDelete);
        await _dbContext.SaveChangesAsync(ct);

        _logger.LogInformation($"{nameof(HotelBranch)} deleted with Id: {hotelBranchId}");

        return Result.Ok(hotelBranchForDelete.Id);
    }

    public async Task<Result<IEnumerable<ResponseHotelBranchDto>>> GetAllAsync(CancellationToken ct)
    {
        const string keyForRedisCache = "hotelBranches";
        IEnumerable<ResponseHotelBranchDto>? hotelBranches;
        var cashedHotelBranches = await _distributedCache.GetStringAsync(keyForRedisCache, ct);
        
        if (string.IsNullOrEmpty(cashedHotelBranches))
        {
            hotelBranches = await _dbContext
                .HotelBranches
                .Select(hb => new ResponseHotelBranchDto()
                {
                    Id = hb.Id,
                    Location = hb.Location,
                    Name = hb.Name
                })
                .ToListAsync(ct);
            _logger.LogInformation($"Retrieved {hotelBranches.Count()} HotelBranches");

            if (hotelBranches.Any())
            {
                await _distributedCache.SetStringAsync(keyForRedisCache, JsonConvert.SerializeObject(hotelBranches), ct);
                _logger.LogInformation($"Cashed list of hotel branches");
            }
            return Result.Ok<IEnumerable<ResponseHotelBranchDto>>(hotelBranches);
        }

        hotelBranches = JsonConvert.DeserializeObject<IEnumerable<ResponseHotelBranchDto>>(cashedHotelBranches);
        return Result.Ok<IEnumerable<ResponseHotelBranchDto>>(hotelBranches);
    }

    public async Task<Result<IEnumerable<ResponseHotelBranchDto>>> GetAllByLocationAsync(
        string country,
        string city,
        CancellationToken ct)
    {
        var keyForRedisCache = $"hotelBranches-{country}-{city}"; 
        IEnumerable<ResponseHotelBranchDto>? hotelBranches;
        var cashedHotelBranches = await _distributedCache.GetStringAsync(keyForRedisCache, ct);
        
        if (string.IsNullOrEmpty(cashedHotelBranches))
        {
            hotelBranches = await _dbContext
                .HotelBranches
                .Include(hb => hb.Location)
                .Where(hb => hb.Location.Country == country && hb.Location.City == city)
                .Select(hb => new ResponseHotelBranchDto()
                {
                    Id = hb.Id,
                    Location = hb.Location,
                    Name = hb.Name
                })
                .ToListAsync(ct);

            _logger.LogInformation($"Retrieved {hotelBranches.Count()} HotelBranches by Location");
            
            if (hotelBranches.Any())
            {
                await _distributedCache.SetStringAsync(keyForRedisCache, JsonConvert.SerializeObject(hotelBranches),
                    ct);
                _logger.LogInformation($"Cashed list of hotel branches");
            }
            return Result.Ok<IEnumerable<ResponseHotelBranchDto>>(hotelBranches);

        }
        
        hotelBranches = JsonConvert.DeserializeObject<IEnumerable<ResponseHotelBranchDto>>(cashedHotelBranches);
        return Result.Ok<IEnumerable<ResponseHotelBranchDto>>(hotelBranches);
    }
}