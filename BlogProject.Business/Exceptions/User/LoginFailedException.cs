namespace BlogProject.Business.Exceptions.User;

public class LoginFailedException : Exception
{
    public LoginFailedException() : base("Username or password reasonse")
    {
    }

    public LoginFailedException(string? message) : base(message)
    {
    }
}
