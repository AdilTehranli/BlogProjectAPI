using BlogProject.Core.Entities;
using BlogProject.DAL.Context;
using BlogProject.DAL.Repositories.Interfaces;

namespace BlogProject.DAL.Repositories.Implements;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(BlogDBContext context) : base(context)
    {
    }
}
