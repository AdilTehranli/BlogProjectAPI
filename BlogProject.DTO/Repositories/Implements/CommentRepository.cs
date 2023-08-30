using BlogProject.Core.Entities;
using BlogProject.DAL.Context;
using BlogProject.DAL.Repositories.Interfaces;

namespace BlogProject.DAL.Repositories.Implements;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(BlogDBContext context) : base(context)
    {
    }
}
