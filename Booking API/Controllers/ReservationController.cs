using Booking_API.DTO.Reservation;
using Booking_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking_API.Controllers;

[Route("api/v1/reservations")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpPost]
    public async Task<IActionResult> ReserveAsync(
        CreateReservationDto createReservationDto, 
        CancellationToken ct)
    {
        var result = await _reservationService.ReserveAsync(createReservationDto, ct);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Reasons);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken ct)
    {
        var result = await _reservationService.GetAllAsync(ct);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Reasons);
    }
}