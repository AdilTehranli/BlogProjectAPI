using FluentValidation;

namespace BlogProject.Business.Dtos.BlogDtos;

public class BlogUpdateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string? CoverImageUrl { get; set; }
}
public class BlogUpdateDtoValidator : AbstractValidator<BlogUpdateDto>
{
    public BlogUpdateDtoValidator()
    {
        RuleFor(t => t.Title).NotEmpty().NotNull().MaximumLength(255);
        RuleFor(t => t.Description).NotEmpty().NotNull();
    }
}
