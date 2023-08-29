using BlogProject.Core.Entities;
using FluentValidation;

namespace BlogProject.Business.Dtos.BlogDtos;

public class BlogCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImageUrl { get; set; }
    public IEnumerable<int> CategoryIds { get; set; }
}
public class BlogCreateDtoValidator : AbstractValidator<BlogCreateDto>
{
    public BlogCreateDtoValidator()
    {
        RuleFor(t => t.Title).NotEmpty().NotNull().MaximumLength(255);
        RuleFor(t => t.Description).NotEmpty().NotNull();
        RuleFor(t => t.CoverImageUrl).NotEmpty().NotNull();
        RuleForEach(t => t.CategoryIds).GreaterThan(0).NotEmpty();


    }
}
