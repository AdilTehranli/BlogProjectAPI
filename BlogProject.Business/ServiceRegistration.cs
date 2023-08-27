using BlogProject.Business.ExtensionServices.Implements;
using BlogProject.Business.ExtensionServices.Interfaces;
using BlogProject.Business.Services.Implements;
using BlogProject.Business.Services.Interfaces;
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
    }
}
