using Booking_API.DataAccess;
using Booking_API.DTO.Amenity;
using Booking_API.Interfaces;
using Booking_API.Models;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;


namespace Booking_API.Services;

public class AmenityService : IAmenityService
{
    private readonly AppDbContext _dbContext;
    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<AmenityService> _logger;

    public AmenityService(AppDbContext appDbContext, IDistributedCache distributedCache, ILogger<AmenityService> logger)
    {
        _dbContext = appDbContext;
        _distributedCache = distributedCache;
        _logger = logger;
    }

    public async Task<Result<Guid>> CreateAsync(CreateAmenityDto createAmenityDto, CancellationToken ct)
    {
        var amenity = new Amenity()
        {
            Id = Guid.NewGuid(),
            Title = createAmenityDto.Title,
            Description = createAmenityDto.Description
        };

        await _dbContext.Amenities.AddAsync(amenity, ct);
        await _dbContext.SaveChangesAsync(ct);

        _logger.LogInformation($"{nameof(Amenity)} created with Id: {amenity.Id}");

        return Result.Ok(amenity.Id);
    }

    public async Task<Result<Guid>> UpdateAsync(UpdateAmenityDto updateAmenityDto, CancellationToken ct)
    {
        var amenityForUpdate = await _dbContext
            .Amenities
            .SingleOrDefaultAsync(a => a.Id == updateAmenityDto.Id, ct);

        if (amenityForUpdate == null)
            return Result.Fail<Guid>("Amenity not found");

        amenityForUpdate.Title = updateAmenityDto.Title;
        amenityForUpdate.Description = updateAmenityDto.Description;

        _dbContext.Update(amenityForUpdate);
        await _dbContext.SaveChangesAsync(ct);

        _logger.LogInformation($"{nameof(Amenity)} updated with Id: {amenityForUpdate.Id}");

        return Result.Ok(amenityForUpdate.Id);
    }

    public async Task<Result<Guid>> DeleteAsync(Guid id, CancellationToken ct)
    {
        var amenityForDelete = await _dbContext
            .Amenities
            .SingleOrDefaultAsync(a => a.Id == id, ct);

        if (amenityForDelete == null)
        {
            return Result.Fail<Guid>("Amenity not found");
        }

        _dbContext.Amenities.Remove(amenityForDelete);
        await _dbContext.SaveChangesAsync(ct);

        _logger.LogInformation($"{nameof(Amenity)} deleted with Id: {amenityForDelete.Id}");
        return Result.Ok(amenityForDelete.Id);
    }

    public async Task<Result<IEnumerable<ResponseAmenityDto>>> GetAllAsync(CancellationToken ct)
    {
        IEnumerable<ResponseAmenityDto>? amenities;
        const string keyForRedisCache = "amenities";
        var cashedAmenities = await _distributedCache.GetStringAsync(keyForRedisCache, ct);

        if (string.IsNullOrEmpty(cashedAmenities))
        {
            amenities = await _dbContext
                .Amenities
                .Select(a => new ResponseAmenityDto
                {
                    Id = a.Id,
                    Name = a.Title,
                    Description = a.Description
                })
                .ToListAsync(ct);

            if (amenities.Any())
            {
                await _distributedCache.SetStringAsync(keyForRedisCache, JsonConvert.SerializeObject(amenities), ct);
                _logger.LogInformation($"Cashed list of amenities");
            }

            _logger.LogInformation($"Retrieved {amenities.Count()} amenities");

            return Result.Ok(amenities);
        }

        amenities = JsonConvert.DeserializeObject<IEnumerable<ResponseAmenityDto>>(cashedAmenities,
            new JsonSerializerSettings()
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            });
        return Result.Ok(amenities);
    }

    private async Task<IEnumerable<ResponseAmenityDto>> GetAmenitiesFromDatabaseAsync(CancellationToken ct)
    {
        return await _dbContext
            .Amenities
            .Select(a => new ResponseAmenityDto
            {
                Id = a.Id,
                Name = a.Title,
                Description = a.Description
            })
            .ToListAsync(ct);
    }
}