using Booking_API.DTO.Room;
using Booking_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking_API.Controllers;

[Route("api/v1/rooms")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllAsync(CancellationToken ct)
    {
        var result = await _roomService.GetAllAsync(ct);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Reasons);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetAllAsync(Guid id, CancellationToken ct)
    {
        var result = await _roomService.GetRoomsByTypeAsync(id, ct);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Reasons);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateRoomDto roomDto, CancellationToken ct)
    {
        var result = await _roomService.CreateAsync(roomDto, ct);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Reasons);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRoomDto([FromBody] UpdateRoomDto roomDto, CancellationToken ct)
    {
        var result = await _roomService.UpdateAsync(roomDto, ct);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Reasons);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteRoomAsync(Guid id, CancellationToken ct)
    {
        var result = await _roomService.DeleteAsync(id, ct);
        if (result.IsSuccess)
            return NoContent();
        return BadRequest(result.Reasons);
    }
    
    [HttpPut]
    [Route("enable/{roomId}")]
    public async Task<IActionResult> EnableRoom(Guid roomId, CancellationToken ct)
    {
        var result = await _roomService.EnableRoomAsync(roomId, ct);
        if (result.IsSuccess)
            return Ok();

        return BadRequest(result.Errors);
    }

    [HttpPut]
    [Route("disable/{roomId}")]
    public async Task<IActionResult> DisableRoom(Guid roomId, CancellationToken ct)
    {
        var result = await _roomService.DisableRoomAsync(roomId, ct);
        if (result.IsSuccess)
            return Ok();

        return BadRequest(result.Errors);
    }
}