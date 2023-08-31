using BlogProject.Core.Entities;
using BlogProject.DAL.Context;
using BlogProject.DAL.Repositories.Interfaces;

namespace BlogProject.DAL.Repositories.Implements;

public class BlogLikeRepository : Repository<BlogLike>, IBlogLikeRepository
{
    public BlogLikeRepository(BlogDBContext context) : base(context)
    {
    }
}
