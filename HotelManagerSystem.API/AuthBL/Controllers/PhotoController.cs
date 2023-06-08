using HotelManagerSystem.API.Service;
using HotelManagerSystem.DAL.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using HotelManagerSystem.Models.Request;

namespace HotelManagerSystem.API.AuthBL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly FotoService fotoService;

        public PhotoController(FotoService fotoService)
        {
            this.fotoService = fotoService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFoto([FromBody] FotoRequest request)
        {
            var response = new FotoResponse();

            try
            {
                var savedFileName = await fotoService.SaveFotoAsync(request.Folder, request.EncodedContent, request.FileName);
                var filePath = $"/{request.Folder}/{savedFileName}";

                response.FileName = savedFileName;
                response.FilePath = filePath;
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessage = e.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult DeleteFoto([FromBody] FotoRequest request)
        {
            var response = new FotoResponse();

            try
            {
                fotoService.DeleteFoto(request.Folder, request.FileName);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessage = e.Message;
            }

            return Ok(response);
        }
    }
}