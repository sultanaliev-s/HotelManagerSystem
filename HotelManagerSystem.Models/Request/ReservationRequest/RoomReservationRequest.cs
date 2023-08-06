namespace HotelManagerSystem.Models.Request.ReservationRequest;

public class RoomReservationRequest
{
    public int RoomId { get; set; } 
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; } 
    public int Person { get; set; } 
}