using HotelManagerSystem.API.Service;
using HotelManagerSystem.DAL.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers
{
    public class FotoController : Controller
    {
        private readonly FotoService fotoService;

        public FotoController(FotoService fotoService)
        {
            this.fotoService = fotoService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFoto(string folder, string encodedContent, string fileName)
        {
            var response = new FotoResponse();

            try
            {
                var savedFileName = await fotoService.SaveFotoAsync(folder, encodedContent, fileName);
                var filePath = $"/{folder}/{savedFileName}";

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
        public IActionResult DeleteFoto(string folder, string fileName)
        {
            var response = new FotoResponse();

            try
            {
                fotoService.DeleteFoto(folder, fileName);
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