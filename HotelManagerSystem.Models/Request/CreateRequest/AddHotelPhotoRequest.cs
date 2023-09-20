using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystem.Models.Request.CreateRequest;

public class AddHotelPhotoRequest
{
    public int HotelId { get; set; }
    public List<IFormFile> Photos { get; set; }
}
