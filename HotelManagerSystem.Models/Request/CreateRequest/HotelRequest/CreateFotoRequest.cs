namespace HotelManagerSystem.Models.Request.CreateRequest.HotelRequest
{
    public class CreateFotoRequest
    {
        public int HotelId { get; set; }
        public string Foto { get; set; }
        public DateTime? CreateDate { get; set; }

        public CreateFotoRequest(int id, string fotos)
        {
            HotelId = id;
            Foto = fotos;
        }
    }
}