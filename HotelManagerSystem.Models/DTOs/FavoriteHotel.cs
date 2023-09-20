using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystem.Models.DTOs
{
    public class FavoriteHotel
    {
        public int Id { get; set; }
        public FavoriteHotelDto Hotel { get; set; }

        public class  FavoriteHotelDto {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal ReviewStars { get; set; }
    }
    }
}
