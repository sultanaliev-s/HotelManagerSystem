using System.Security.Claims;
using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.Models.Entities.ModelOwner;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly OwnerManager _ownerManager;

        public OwnerController(IMediator mediator, OwnerManager ownerManager)
        {
            _mediator = mediator;
            _ownerManager = ownerManager;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterOwner(RegisterOwnerRequest request)
        {
            var response = await _ownerManager.RegisterOwner(request);
            return response.StatusCode switch
            {
                200 => Created("", null),
                400 => BadRequest(new ErrorResponse(response.Message)),
                404 => NotFound(),
                _ => StatusCode(response.StatusCode, new ErrorResponse(response.Message))
            };
        }

        [Authorize(Roles = "Owner")]
        [HttpPut("UpdateOwner")]
        public async Task<IActionResult> UpdateOwner(UpdateOwnerRequest request)
        {
            var response = await _ownerManager.UpdateOwner(request);
            return response.StatusCode switch
            {
                200 => Ok(),
                400 => BadRequest(new ErrorResponse(response.Message)),
                404 => NotFound(),
                _ => StatusCode(response.StatusCode, new ErrorResponse(response.Message))
            };
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpDelete("DeleteOwner")]
        public async Task<IActionResult> DeleteOwner(string id)
        {
            if (!User.IsInRole("Admin") && User.FindFirstValue(ClaimTypes.NameIdentifier) != id)
            {
                return Forbid();
            }
            var success = await _ownerManager.DeleteOwner(id);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getallowners")]
        public async Task<IActionResult> GetAllOwners()
        {
            try
            {
                List<OwnerViewModel> owners = await _ownerManager.GetAllOwners();
                return Ok(owners);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetOwnerById")]
        public async Task<IActionResult> GetOwnerById(string id)
        {
            var query = new GetOwnerByIdQuery(id);
            var owner = await _mediator.Send(query);
            if (owner == null)
                return NotFound();

            return Ok(owner);
        }

        [HttpGet("current")]
        [Authorize]
        public async Task<IActionResult> GetCurrentOwner()
        {
            var query = new GetCurrentOwnerQuery(User);
            var owner = await _mediator.Send(query);
            if (owner == null)
                return NotFound();

            return Ok(owner);
        }
    }
}
