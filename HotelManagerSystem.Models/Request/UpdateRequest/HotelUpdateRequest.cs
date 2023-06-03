using HotelManagerSystem.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace HotelManagerSystem.Models.Request.UpdateRequest
{
    public class HotelUpdateRequest
    {
        public int Id { get; set; }
        public List<Address>? Addresses { get; set; }
        public List<Room>? Rooms { get; set; }
        public List<ClientReview>? ClientReviews { get; set; }
        public List<HotelFoto>? Fotos { get; set; }
    }
}