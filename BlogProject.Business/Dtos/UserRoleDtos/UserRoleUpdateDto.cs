using FluentValidation;

namespace BlogProject.Business.Dtos.UserRoleDtos;

public class UserRoleUpdateDto
{
   public string RoleName { get; set; }

}
public class UserRoleUpdateDtoValidator : AbstractValidator<UserRoleUpdateDto>
{
    public UserRoleUpdateDtoValidator()
    {
         RuleFor(x => x.RoleName).NotEmpty().WithMessage("role not empty")
            .NotNull().WithMessage("Role not null").
            MaximumLength(15).WithMessage("It cannot be bigger than 15");
    }
}
