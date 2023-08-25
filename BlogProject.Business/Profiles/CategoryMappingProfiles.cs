using AutoMapper;
using BlogProject.Business.Dtos.CategoryDtos;
using BlogProject.Core.Entities;

namespace BlogProject.Business.Profiles;

public class CategoryMappingProfiles:Profile
{
    public CategoryMappingProfiles() {
        CreateMap<Category, CategoryDetailDto>();
        CreateMap<Category, CategoryListItemDto>();
        CreateMap<CategoryCreateDto, Category>();
        CreateMap<CategoryUpdateDto,Category>();
    }
}
