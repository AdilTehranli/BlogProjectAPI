using AutoMapper;
using BlogProject.Business.Dtos.BlogDtos;
using BlogProject.Business.Services.Interfaces;
using BlogProject.Core.Entities;
using BlogProject.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Security.Claims;

namespace BlogProject.Business.Services.Implements;

public class BlogService : IBlogService
{
    readonly IBlogRepository _blogRepository;
    readonly IHttpContextAccessor _httpContextAccessor;
    readonly string UserId;
    readonly IMapper _mapper;
    readonly UserManager<AppUser> _userManager;
    readonly ICategoryRepository _categoryRepository;
    public BlogService(IBlogRepository blogRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<AppUser> userManager = null, ICategoryRepository categoryRepository = null)
    {
        _blogRepository = blogRepository;
        _httpContextAccessor = httpContextAccessor;
        UserId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        _mapper = mapper;
        _userManager = userManager;
        _categoryRepository = categoryRepository;
    }

    public async Task CreateAsync(BlogCreateDto dto)
    {
        if (string.IsNullOrEmpty(UserId)) throw new ArgumentNullException();
        if (!await _userManager.Users.AnyAsync(u => u.Id == UserId)) throw new ArgumentException();
        List<BlogCategory> blogs = new();
        Blog blog = _mapper.Map<Blog>(dto);
        foreach (var id in dto.CategoryIds)
        {
            var cat = await _categoryRepository.FindByIdAsync(id);
            if (cat != null) throw new NullReferenceException();
            blogs.Add(new BlogCategory { Category = cat, Blog = blog });
        }
        blog.AppUserId= UserId;
        blog.BlogCategories = blogs;
        await _blogRepository.CreateAsync(blog);
        await _blogRepository.SaveAsync();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BlogListItemDto>> GetAllAsync()

    {
        var entity = _blogRepository.GetAll("AppUser", "BlogCategories", "BlogCategories.Category");
        return _mapper.Map<IEnumerable<BlogListItemDto>>(entity); 
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
