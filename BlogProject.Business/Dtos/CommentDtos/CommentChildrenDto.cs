using BlogProject.Business.Dtos.UserAuthDtos;

namespace BlogProject.Business.Dtos.CommentDtos;

public record CommentChildrenDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public AuthorDto AppUser { get; set; }
}
