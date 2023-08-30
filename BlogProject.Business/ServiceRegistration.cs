using BlogProject.Business.ExtensionServices.Implements;
using BlogProject.Business.ExtensionServices.Interfaces;
using BlogProject.Business.ExternalServices.Implements;
using BlogProject.Business.ExternalServices.Interfaces;
using BlogProject.Business.Services.Implements;
using BlogProject.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace BlogProject.Business;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IBlogService, BlogService>();
        services.AddScoped<ICommentService,CommentService>();
        services.AddHttpContextAccessor();


    }
}
