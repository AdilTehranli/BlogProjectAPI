using BlogProject.DAL.Repositories.Implements;
using BlogProject.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlogProject.DAL;

public static class ServiceRegistration
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository,CategoryRepository>();
        services.AddScoped<IBlogRepository,BlogRepository>();
    }
}
