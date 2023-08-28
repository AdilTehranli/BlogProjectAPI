using AutoMapper;
using BlogProject.Business.Dtos.BlogDtos;
using BlogProject.Business.Services.Interfaces;
using BlogProject.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BlogProject.Business.Services.Implements;

public class BlogService : IBlogService
{
    readonly IBlogRepository _blogRepository;
    readonly HttpContextAccessor _httpContextAccessor;
    readonly string UserId;
    readonly IMapper _mapper;
    public BlogService(IBlogRepository blogRepository, HttpContextAccessor httpContextAccessor, string userId, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _httpContextAccessor = httpContextAccessor;
        UserId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        _mapper = mapper;
    }

    public Task CreateAsync(BlogCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BlogListItemDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<BlogListItemDto>>(_blogRepository.GetAll("AppUser"));
    }

    public Task<BlogDetailDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, BlogUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
