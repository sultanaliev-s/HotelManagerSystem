using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystem.Models.DTOs;
public class ReservationDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public DateTime ReserveStart { get; set; }
    public DateTime ReserveEnd { get; set; }
    public int Person { get; set; }
    public decimal Price { get; set; }
    public ReservationRoomDto Room { get; set; }

    public class ReservationRoomDto {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Smoke { get; set; }
        public int BasePerson { get; set; }
        public HotelDto Hotel { get; set; }

        public class HotelDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        
    }
}
