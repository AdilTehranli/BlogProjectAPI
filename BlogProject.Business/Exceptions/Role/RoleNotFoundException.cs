using BlogProject.Business.Exceptions.Commons;
using Microsoft.AspNetCore.Http;

namespace BlogProject.Business.Exceptions.Role;

public class RoleNotFoundException : Exception, IBaseException
{
    public int StatusCode => StatusCodes.Status404NotFound;
    public string ErrorMessage { get;}
    public RoleNotFoundException()
    {
        ErrorMessage = "Role Not Found";
    }

    public RoleNotFoundException(string? message) : base(message)
    {
        ErrorMessage = message;
    }


}
