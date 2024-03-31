using Booking_API.DTO.HotelBranch;
using Booking_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking_API.Controllers;

[Route("api/v1/hotel-branch")]
[ApiController]
public class HotelBranchController : Controller
{
    private readonly IHotelBranchService _hotelBranchService;

    public HotelBranchController(IHotelBranchService hotelBranchService)
    {
        _hotelBranchService = hotelBranchService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateHotelBranchDto hotelBranchDto, CancellationToken ct)
    {
        var result = await _hotelBranchService.CreateAsync(hotelBranchDto, ct);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Reasons);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] UpdateHotelBranchDto hotelBranchDto, CancellationToken ct)
    {
        var result = await _hotelBranchService.UpdateAsync(hotelBranchDto, ct);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Reasons);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAsync(Guid hotelBranchId, CancellationToken ct)
    {
        var result = await _hotelBranchService.DeleteAsync(hotelBranchId, ct);
        if (result.IsSuccess)
            return NoContent();
        return BadRequest(result.Reasons);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResponseHotelBranchDto>>> GetAllAsync(CancellationToken ct)
    {
        var result = await _hotelBranchService.GetAllAsync(ct);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Reasons);
    }

    [HttpGet]
    [Route("{country}/{city}")]
    public async Task<ActionResult<IEnumerable<ResponseHotelBranchDto>>> GetAllByLocationAsync(
        string country,
        string city,
        CancellationToken ct)
    {
        var result = await _hotelBranchService.GetAllByLocationAsync(country, city, ct);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Reasons);
    }
}