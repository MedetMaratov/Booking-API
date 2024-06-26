using Booking_API.DTO.RoomType;
using Booking_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking_API.Controllers;

[Route("api/v1/room-types")]
[ApiController]
public class RoomTypeController : ControllerBase
{
    private readonly IRoomTypeService _roomTypeService;

    public RoomTypeController(IRoomTypeService roomTypeService)
    {
        _roomTypeService = roomTypeService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateRoomTypeDto roomTypeDto, 
        CancellationToken ct)
    {
        var result = await _roomTypeService.CreateAsync(roomTypeDto, ct);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Reasons);
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        [FromBody] UpdateRoomTypeDto roomTypeDto, 
        CancellationToken ct)
    {
        var result = await _roomTypeService.UpdateAsync(roomTypeDto, ct);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Reasons);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await _roomTypeService.DeleteAsync(id, ct);
        if (result.IsSuccess)
            return NoContent();
        return BadRequest(result.Reasons);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResponseRoomTypeDto>>> GetAll(CancellationToken ct)
    {
        var result = await _roomTypeService.GetAllRoomTypesAsync(ct);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Reasons);
    }
}