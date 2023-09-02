using BlogProject.Business.Dtos.BlogDtos;
using BlogProject.Business.Dtos.CategoryDtos;
using BlogProject.Core.Entities;

namespace BlogProject.Business.Services.Interfaces;

public interface IBlogService
{
    Task<IEnumerable<BlogListItemDto>> GetAllAsync();
    Task<BlogDetailDto> GetByIdAsync(int id);
    Task CreateAsync(BlogCreateDto dto);
    Task UpdateAsync(int id, BlogUpdateDto dto);
    Task DeleteAsync(int id);
    Task ReactAsync(int id,Reactions reaction);
    Task RemoveReactAsync(int id);
}
