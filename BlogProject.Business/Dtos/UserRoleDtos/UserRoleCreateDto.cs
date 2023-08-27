using FluentValidation;
using FluentValidation.AspNetCore;

namespace BlogProject.Business.Dtos.UserRoleDtos;

public class UserRoleCreateDto
{
    public string RoleName { get; set; }
}
public class UserRoleCreateDtoValidator : AbstractValidator<UserRoleCreateDto>
{
    public UserRoleCreateDtoValidator()
    {
        RuleFor(x => x.RoleName).NotEmpty().WithMessage("role not empty")
            .NotNull().WithMessage("Role not null").
            MaximumLength(15).WithMessage("It cannot be bigger than 15");
    }
}

