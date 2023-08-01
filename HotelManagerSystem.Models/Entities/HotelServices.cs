using HotelManagerSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagerSystem.Models.Common;
using HotelManagerSystem.Models.Entities.Relations;

namespace HotelManagerSystem.Models.Entities
{
    public class HotelServices : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<HotelsServices> Services { get; set; }
    }
}
