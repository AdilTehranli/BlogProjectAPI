namespace BlogProject.Business.Exceptions.Commons;

public class NotFoundException<T> : Exception where T : class
{
    public NotFoundException() : base(typeof(T).Name + "Not Found") 
    {
    }

    public NotFoundException(string? message) : base(message)
    {
    }
}
