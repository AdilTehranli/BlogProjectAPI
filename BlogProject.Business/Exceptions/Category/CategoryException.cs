namespace BlogProject.Business.Exceptions.Category;

public class CategoryException : Exception
{
    public CategoryException() : base("Category cannot be found") { }
   

    public CategoryException(string? message) : base(message)
    {
    }
}
