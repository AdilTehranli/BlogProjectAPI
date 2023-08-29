using AutoMapper;
using BlogProject.Business.Dtos.BlogDtos;
using BlogProject.Business.Dtos.CategoryDtos;
using BlogProject.Core.Entities;

namespace BlogProject.Business.Profiles;

public class BlogMappingProfiles:Profile
{
    public BlogMappingProfiles()
    {
        CreateMap<Blog, BlogDetailDto>();
        CreateMap<Blog, BlogListItemDto>();
        CreateMap<BlogCreateDto, Blog>();
        CreateMap<BlogUpdateDto, Blog>();
        CreateMap<BlogCategory, BlogCategoryDto>();
    }
}
