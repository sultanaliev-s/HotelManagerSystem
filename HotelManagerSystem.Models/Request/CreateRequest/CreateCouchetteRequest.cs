using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystem.Models.Request.CreateRequest;

public class CreateCouchetteRequest
{
    public string Name { get; set; }
    public int RoomId { get; set; }
}
