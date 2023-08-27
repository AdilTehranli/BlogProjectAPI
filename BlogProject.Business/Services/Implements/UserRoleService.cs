using BlogProject.Business.Dtos.UserRoleDtos;
using BlogProject.Business.Services.Interfaces;
using BlogProject.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Business.Services.Implements;

public class UserRoleService : IUserRoleService 
{
    readonly RoleManager<IdentityRole> _roleManager;

    public UserRoleService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<IEnumerable<UserRoleListItemDto>> GetAllAsync()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        if (roles == null) throw new Exception();
        var roleList = roles.Select(r => new UserRoleListItemDto
        {
           RoleName=r.Name
        }).ToList();

        return roleList;
    }


    public async Task CreateAsync(UserRoleCreateDto dto)
    {
        IdentityRole identity = new IdentityRole();
        await _roleManager.CreateAsync(identity);
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UserRoleUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
