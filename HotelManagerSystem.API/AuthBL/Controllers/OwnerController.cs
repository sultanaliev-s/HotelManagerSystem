using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Entities.ModelOwner;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var response = await _mediator.Send(request);
            return Ok(response);
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

        [HttpPut("UpdateOwner")]
        public async Task<IActionResult> UpdateOwner(string id, UpdateOwnerRequest request)
        {
            request.Id = int.Parse(id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("DeleteOwner")]
        public async Task<IActionResult> DeleteOwner(string id)
        {
            var command = new DeleteOwnerCommand(id);
            var success = await _mediator.Send(command);
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
    }
}
