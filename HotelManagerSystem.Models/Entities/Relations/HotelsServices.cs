using HotelManagerSystem.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagerSystem.Models.Entities.Relations
{
    [Table("HotelsServicesRelation")]
    public class HotelsServices : BaseEntity<int> 
    {
        public int HotelServiceId { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public HotelServices HotelService { get; set; }
    }
}