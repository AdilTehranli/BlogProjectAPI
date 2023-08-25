using AutoMapper;
using BlogProject.Business.Dtos.CategoryDtos;
using BlogProject.Business.Exceptions.Category;
using BlogProject.Business.Exceptions.Commons;
using BlogProject.Business.ExtensionServices.Interfaces;
using BlogProject.Business.Services.Interfaces;
using BlogProject.Core.Entities;
using BlogProject.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Business.Services.Implements;

public class CategoryService : ICategoryService
{
    readonly ICategoryRepository _repository;
    readonly IFileService _fileService;
    readonly IMapper _mapper;
    public CategoryService(ICategoryRepository repository, IFileService fileService, IMapper mapper)
    {
        _repository = repository;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async Task CreateAsync(CategoryCreateDto dto)
    {
        Category category = new Category()
        {
            Name = dto.Name,
            LogoUrl = await _fileService.UploadAsync(dto.Logo,Path.Combine("images","img")),
            IsDeleted = false,

        };
      await _repository.CreateAsync(category);
        await _repository.SaveAsync();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    //public async Task<IEnumerable<Category>> GetAllAsync()
    //{
    //   return await _repository.GetAll().ToListAsync();
    //}

    public async Task<Category> GetByIdAsync(int id)
    {
        if (id <= 0) throw new NegativeIdException();
        var entity = await _repository.FindByIdAsync(id);
        if (entity == null) throw new CategoryException();
        return entity;
    }

    public Task UpdateAsync(CategoryUpdateDto dto)
    {
        throw new NotImplementedException();
    }

   public async Task<IEnumerable<CategoryListItemDto>> GetAllAsync()
    {
       return _mapper.Map<IEnumerable<CategoryListItemDto>>(_repository.GetAll());
    }

    Task<CategoryDetailDto> ICategoryService.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
