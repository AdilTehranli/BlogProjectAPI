namespace BlogProject.Business.Dtos.BlogDtos;

public class BlogDetailDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string? CoverImageUrl { get; set; }
}
