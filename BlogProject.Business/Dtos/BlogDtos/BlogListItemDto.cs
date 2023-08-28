using BlogProject.Business.Dtos.UserAuthDtos;
using BlogProject.Core.Entities;

namespace BlogProject.Business.Dtos.BlogDtos;

public class BlogListItemDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int ViewewCount { get; set; }
    public string CoverImageUrl { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedTime { get; set; }
    public AuthorDto AppUser { get; set; }
    public IEnumerable<Category> Categories { get; set; }
}
