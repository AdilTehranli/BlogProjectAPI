using BlogProject.Business.Dtos.CommentDtos;

namespace BlogProject.Business.Services.Interfaces;

public interface ICommentService
{
   public Task<IEnumerable<CommentListItemDto>> GetAllAsync(int id);
    public Task CreateAsync(int id, CommentCreateDto dto);
}
