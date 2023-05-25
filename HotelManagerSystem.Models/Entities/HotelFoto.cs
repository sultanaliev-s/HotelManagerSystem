using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Common;


namespace HotelManagerSystem.Models.Entities
{
    public class HotelFoto : BaseEntity<int>
    {
        public string Foto { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}