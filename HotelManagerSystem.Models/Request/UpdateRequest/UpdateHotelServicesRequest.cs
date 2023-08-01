using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystem.Models.Request.UpdateRequest;

public class UpdateHotelServicesRequest
{
    public int Id { get; set; }
    public List<int> HotelServicesId { get; set; }
}
