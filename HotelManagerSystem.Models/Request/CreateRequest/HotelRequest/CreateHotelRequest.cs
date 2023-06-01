using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.Models.Request.CreateRequest.HotelRequest
{
    public class CreateHotelRequest
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsOne { get; set; }
        public string CheckingAccount { get; set; }
        public int FilialCount { get; set; }
        public int HotelTypeId { get; set; }
        public int HotelCategoryId { get; set; }
        public List<HotelFoto> Fotos { get; set; }
        public DateTime CreateDate { get; set; }
    }
}