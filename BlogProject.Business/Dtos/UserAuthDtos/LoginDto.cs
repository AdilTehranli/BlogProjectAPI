using FluentValidation;

namespace BlogProject.Business.Dtos.UserDtos;

public class LoginDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(r => r.UserName).NotEmpty().NotNull().MinimumLength(3).MaximumLength(75);
        RuleFor(a => a.Password).NotNull().NotEmpty().MinimumLength(6);

    }
}
