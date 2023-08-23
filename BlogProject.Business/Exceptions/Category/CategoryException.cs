namespace BlogProject.Business.Exceptions.Category;

public class CategoryException : Exception
{
    public CategoryException() : base("Category cannot be empty") { }
   

    public CategoryException(string? message) : base(message)
    {
    }
}
