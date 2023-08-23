using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BlogProject.Business.Dtos.CategoryDtos;

public record CategoryCreateDto
{
    public string Name { get; set; }
    public IFormFile Logo { get; set; }
}
public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Bos ola bilmez")
            .NotNull().WithMessage("Null Ola bilmez")
            .MaximumLength(64).WithMessage("Kategoriya adi 64 herfden cox ola bilmez");
        RuleFor(c => c.Logo)
            .NotNull().WithMessage("Kategoriya sekili null ola bilmez");
            
    }
}
