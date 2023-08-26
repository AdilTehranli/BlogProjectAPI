namespace BlogProject.Business.Exceptions.User;

public class UserFailedException : Exception
{
    public UserFailedException():base("register failed for same reasonse")
    {
    }

    public UserFailedException(string? message) : base(message)
    {
    }
}
