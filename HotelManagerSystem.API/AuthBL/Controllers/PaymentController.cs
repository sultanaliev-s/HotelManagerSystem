using HotelManagerSystem.API.Repositories;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.DAL.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        private readonly IHotelRepository _hotelRepository;

        public PaymentController(IMediator mediator, IUserRepository userRepository, IHotelRepository hotelRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
            _hotelRepository = hotelRepository;
        }

        [HttpPost]
        [Route("make-payment")]
        public async Task<IActionResult> MakePayment([FromBody] PaymentRequest request)
        {
            var user = await _userRepository.GetUserById(request.UserId);
            var hotel = await _hotelRepository.GetHotelById(request.HotelId);
            
            if (string.IsNullOrEmpty(request.CardNumber))
            {
                return BadRequest("Card number is required");
            }
            
            var paymentResponse = await _mediator.Send(request);

            if (paymentResponse.Success)
            {
                return Ok(new Response(200, true, "Payment successful"));
            }
            else
            {
                return BadRequest(new Response(400, false, "Payment failed"));
            }
        }
    }
}