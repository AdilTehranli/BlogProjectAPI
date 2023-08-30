using BlogProject.Business.Dtos.UserAuthDtos;

namespace BlogProject.Business.Dtos.CommentDtos;

public record CommentListItemDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime CreatedTime { get; set; }
    public AuthorDto AppUser { get; set; }
    public IEnumerable<CommentChildrenDto> Children { get;}
}
