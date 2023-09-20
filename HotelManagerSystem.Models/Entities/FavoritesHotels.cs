using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystem.Models.Entities
{
    public class FavoritesHotels
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int HotelId { get; set; }
        public User User { get; set; }
        public Hotel Hotel { get; set; }
    }
}
