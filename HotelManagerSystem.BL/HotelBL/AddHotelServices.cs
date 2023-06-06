using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.BL.HotelBL
{
    public class AddHotelServices
    {
        public int hotelId { get; set; }
        List<int> services { get; set; }

        public AddHotelServices(int id, List<int> list)
        {
            hotelId = id;
            services = list;
        }
    }
}