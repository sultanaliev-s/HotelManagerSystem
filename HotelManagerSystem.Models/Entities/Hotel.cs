using HotelManagerSystem.Models.Common;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities.Relations;

namespace HotelManagerSystem.Models.Entities
{
    public class Hotel : BaseEntity<int>
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ReviewStars { get; set; }
        public bool IsOne { get; set; }
        public string CheckingAccount { get; set; }
        public int FilialCount { get; set; }

        public int cityId { get; set; }
        public City city { get; set; }

        public int HotelTypeId { get; set; }
        public HotelType Type { get; set; }
        public int HotelCategoryId { get; set; }
        public HotelCategory Category { get; set; }
        public List<Address>? Addresses { get; set; }
        public List<Room> Rooms { get; set; }
        public List<ClientReview>? ClientReviews { get; set; }
        public List<HotelFoto>? Fotos { get; set; }
        public List<HotelsServices> Services { get; set; }
    }
}