using BlogProject.Business.Dtos.UserRoleDtos;

namespace BlogProject.Business.Services.Interfaces;

public interface IUserRoleService
{
    Task<IEnumerable<UserRoleListItemDto>> GetAllAsync();
    Task CreateAsync(UserRoleCreateDto dto);
    Task UpdateAsync(UserRoleUpdateDto dto);
    Task Delete(int id);
}
