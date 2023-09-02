using BlogProject.Business.Dtos.UserAuthDtos;
using BlogProject.Business.Dtos.UserDtos;

namespace BlogProject.Business.Services.Interfaces;

public interface IUserService
{
    Task Register(RegisterDto dto);
    Task<TokenResponceDto> Login(LoginDto dto);
    Task<ICollection<UserWithRoleDto>> GetAllAsync();
    Task AddRoleAsync(string roleName, string userName);
    Task RomoveRoleAsync(string roleName, string userName);
}
