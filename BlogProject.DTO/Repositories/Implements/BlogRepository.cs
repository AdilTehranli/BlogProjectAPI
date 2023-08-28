using BlogProject.Core.Entities;
using BlogProject.DAL.Context;
using BlogProject.DAL.Repositories.Interfaces;

namespace BlogProject.DAL.Repositories.Implements;

public class BlogRepository : Repository<Blog>, IBlogRepository
{
    public BlogRepository(BlogDBContext context) : base(context)
    {
    }
}
