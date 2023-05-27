using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagerSystem.Models.Common;
using System.Threading.Tasks;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.Models.Data
{
    public class Country : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<City> Cities { get; set;}
        public List<Address> Address { get; set;}
    }
}
