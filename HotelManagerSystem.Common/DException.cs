namespace HotelManagerSystem.Common;

public class DException : Exception
{
    public DException()
    {
    }

    public DException(string msg) : base(msg)
    {
    }

    public override string StackTrace => string.Empty;
}