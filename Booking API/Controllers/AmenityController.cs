using Booking_API.DTO.Amenity;
using Booking_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking_API.Controllers;

[Route("api/v1/amenities")]
[ApiController]
public class AmenityController : ControllerBase
{
    private readonly IAmenityService _amenityService;

    public AmenityController(IAmenityService amenityService)
    {
        _amenityService = amenityService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAmenityDto amenityDto, CancellationToken ct)
    {
        var result = await _amenityService.CreateAsync(amenityDto, ct);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Reasons);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAmenityDto amenityDto, CancellationToken ct)
    {
        var result = await _amenityService.UpdateAsync(amenityDto, ct);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Reasons);
    }

    [HttpDelete]
    [Route("id")]
    public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken ct)
    {
        var result = await _amenityService.DeleteAsync(id, ct);
        if (result.IsSuccess)
            return NoContent();
        return BadRequest(result.Reasons);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResponseAmenityDto>>> GetAll(CancellationToken ct)
    {
        var result = await _amenityService.GetAllAsync(ct);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Reasons);
    }
}