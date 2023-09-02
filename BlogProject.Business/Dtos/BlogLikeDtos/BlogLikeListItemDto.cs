using BlogProject.Business.Dtos.UserAuthDtos;
using BlogProject.Core.Entities;

namespace BlogProject.Business.Dtos.BlogLikeDtos;

public class BlogLikeListItemDto
{
    public int Id { get; set; }
    public int BlogId { get; set; }
    public AuthorDto AppUser { get; set; }
    public Reactions Reaction { get; set; }
}
