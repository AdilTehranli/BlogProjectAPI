using BlogProject.Business.Dtos.UserDtos;

namespace BlogProject.Business.Services.Interfaces;

public interface IUserService
{
    Task Register(RegisterDto dto);
}
