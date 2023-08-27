using FluentValidation;
using System.Text.RegularExpressions;

namespace BlogProject.Business.Dtos.UserDtos;

public class RegisterDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password  { get; set; }
    public string ConfirmPassword { get; set; }
}
public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(r => r.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(35);
        RuleFor(r=>r.Surname).NotEmpty().NotNull().MinimumLength(3).MaximumLength(45);
        RuleFor(r => r.UserName).NotEmpty().NotNull().MinimumLength(3).MaximumLength(75);
        RuleFor(r => r.Email).Must(
                u =>
                {
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    var result = regex.Match(u);
                    return result.Success;
                })
            .WithMessage("Please type email");
        RuleFor(a => a.Password).NotNull().NotEmpty().MinimumLength(6);
        RuleFor(a => a).Must(u => u.Password == u.ConfirmPassword)
            .WithMessage("passwor must be equal password");
        

    }
}
