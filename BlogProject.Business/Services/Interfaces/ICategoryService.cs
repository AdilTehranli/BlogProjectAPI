using BlogProject.Business.Dtos.CategoryDtos;
using BlogProject.Core.Entities;

namespace BlogProject.Business.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryListItemDto>> GetAllAsync();
    Task<CategoryDetailDto> GetByIdAsync(int id);
    Task CreateAsync(CategoryCreateDto dto);
    Task UpdateAsync(int id,CategoryUpdateDto dto);
    Task DeleteAsync(int id);
}
