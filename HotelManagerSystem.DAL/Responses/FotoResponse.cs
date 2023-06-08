namespace HotelManagerSystem.DAL.Responses;

public class FotoResponse
{
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; }
}