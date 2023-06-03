namespace HotelManagerSystem.DAL.Responses;

public class PaymentResponse
{
    public int StatusCode { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
}