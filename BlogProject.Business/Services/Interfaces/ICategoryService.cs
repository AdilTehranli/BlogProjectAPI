using BlogProject.Core.Entities;

namespace BlogProject.Business.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);
}
