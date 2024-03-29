﻿using Microsoft.AspNetCore.Http;

namespace BlogProject.Business.Exceptions.Commons;

public class NotFoundException<T> : Exception,IBaseException where T : class
{
    public int StatusCode => StatusCodes.Status404NotFound;
    public string ErrorMessage { get;}
    public NotFoundException() : base() 
    {
        ErrorMessage = typeof(T).Name + "Not Found";
    }

    public NotFoundException(string? message) : base(message)
    {
        ErrorMessage = message;
    }


}
