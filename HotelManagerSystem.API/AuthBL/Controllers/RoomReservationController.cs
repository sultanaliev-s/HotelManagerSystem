using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.Common;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Request.ReservationRequest;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers;

[ApiController]
[Route("api/reservations")]
public class RoomReservationController : ControllerBase
{
    private readonly AuthManager _authManager;

    public RoomReservationController(AuthManager authManager)
    {
        _authManager = authManager;
    }

    [HttpPost]
    [Route("make")]
    public async Task<IActionResult> MakeReservation(RoomReservationRequest request)
    {
        try
        {
            Response response = await _authManager.MakeReservation(request);
            return Ok(response);
        }
        catch (DException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("cancel/{reservationId}")]
    public async Task<IActionResult> CancelReservation(int reservationId)
    {
        try
        {
            Response response = await _authManager.CancelReservation(reservationId);
            return Ok(response);
        }
        catch (DException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}