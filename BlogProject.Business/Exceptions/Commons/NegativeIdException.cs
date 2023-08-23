namespace BlogProject.Business.Exceptions.Commons;

public class NegativeIdException : Exception
{
    public NegativeIdException() : base("Id cannot be less than 0") { }
    

    public NegativeIdException(string? message) : base(message)
    {
    }
}
