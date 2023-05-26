using Microsoft.AspNetCore.Identity;
using HotelManagerSystem.Models.Common;


namespace HotelManagerSystem.Models.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string CheckingAccount { get; set; }


        public List<ClientReview> clientReviews { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<RoomReservation> roomReservations { get; set; }
    }
}
