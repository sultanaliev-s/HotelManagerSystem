using HotelManagerSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagerSystem.Models.Common;


namespace HotelManagerSystem.Models.Data
{
    public class HotelServices : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
