using HotelManagerSystem.DAL.Responses;
using MediatR;

namespace HotelManagerSystem.API.Request;

public class PaymentRequest : IRequest<PaymentResponse>
{
    public int UserId { get; set; }
    public int HotelId { get; set; }
    public decimal Amount { get; set; }
    public string CardNumber { get; set; }
}