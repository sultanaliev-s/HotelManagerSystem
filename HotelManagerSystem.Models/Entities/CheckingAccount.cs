namespace HotelManagerSystem.Models.Entities;

public class CheckingAccount
{
    public string BankName { get; set; }
    public string BankCardNumber { get; set; }
    public decimal Balance { get; set; }
    public string CardNumber { get; set; }
        
    public User User { get; set; }
    public Hotel Hotel { get; set; }
}
