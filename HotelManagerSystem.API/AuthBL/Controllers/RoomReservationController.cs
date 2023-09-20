using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.Common;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Request.ReservationRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelManagerSystem.API.AuthBL.Controllers;

[ApiController]
[Authorize]
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Response response = await _authManager.MakeReservation(request, userId);
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


    [HttpGet]
    [Route("myReservations")]
    public async Task<ActionResult<List<ReservationDto>>> MyReservations()
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _authManager.GetMyReservation(userId);
            return Ok(response);
        }
        catch (DException ex)
        {
            return BadRequest(new ErrorResponse(ex.Message));
        }
    }
}