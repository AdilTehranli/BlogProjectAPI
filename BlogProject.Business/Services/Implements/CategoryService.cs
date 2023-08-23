using BlogProject.Business.Dtos.CategoryDtos;
using BlogProject.Business.Exceptions.Category;
using BlogProject.Business.Exceptions.Commons;
using BlogProject.Business.Services.Interfaces;
using BlogProject.Core.Entities;
using BlogProject.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Business.Services.Implements;

public class CategoryService : ICategoryService
{
    readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(CategoryCreateDto dto)
    {
        Category category = new Category()
        {
            Name = dto.Name,
            LogoUrl = "123",
            IsDeleted = false,

        };
      await _repository.CreateAsync(category);
        await _repository.SaveAsync();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
       return await _repository.GetAll().ToListAsync();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        if (id <= 0) throw new NegativeIdException();
        var entity = await _repository.FindByIdAsync(id);
        if (entity == null) throw new CategoryException();
        return entity;
    }
}
