using HotelManagerSystem.API.Request;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
using MediatR;
using HotelManagerSystem.API.Repositories;

namespace HotelManagerSystem.API.Handlers
{
    public class PaymentHandler : IRequestHandler<PaymentRequest, PaymentResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHotelRepository _hotelRepository;

        public PaymentHandler(IUserRepository userRepository, IHotelRepository hotelRepository)
        {
            _userRepository = userRepository;
            _hotelRepository = hotelRepository;
        }

        public async Task<PaymentResponse> Handle(PaymentRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.UserId);
            var hotel = await _hotelRepository.GetHotelById(request.HotelId);

            if (string.IsNullOrEmpty(user.CheckingAccount) || string.IsNullOrEmpty(hotel.CheckingAccount))
            {
                return new PaymentResponse
                {
                    Success = false,
                    Message = "One or both parties do not have a checking account"
                };
            }

            bool paymentSuccess = PerformPayment(user, hotel, request.Amount);

            if (paymentSuccess)
            {
                int userId = int.Parse(user.Id);
                await _userRepository.UpdateUserBalance(userId, user.CheckingAccount);
                await _hotelRepository.UpdateHotelBalance(hotel.Id, hotel.CheckingAccount);

                return new PaymentResponse
                {
                    Success = true,
                    Message = "Payment successful"
                };
            }
            else
            {
                return new PaymentResponse
                {
                    Success = false,
                    Message = "Payment failed"
                };
            }
        }

        private bool PerformPayment(User user, Hotel hotel, decimal amount)
        {
            if (!decimal.TryParse(user.CheckingAccount, out decimal userBalance) || userBalance < amount)
            {
                return false;
            }

            userBalance -= amount;
            user.CheckingAccount = userBalance.ToString();

            if (decimal.TryParse(hotel.CheckingAccount, out decimal hotelBalance))
            {
                hotelBalance += amount;
                hotel.CheckingAccount = hotelBalance.ToString();
            }
            return true;
        }
    }
}
