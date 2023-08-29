using BlogProject.Business.Dtos.UserRoleDtos;
using BlogProject.Business.Services.Interfaces;
using BlogProject.Core.Entities;
using BlogProject.DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace BlogProject.Business.Services.Implements;

public class UserRoleService : IUserRoleService 
{
    readonly RoleManager<IdentityRole> _roleManager;
    readonly BlogDBContext _blogDBContext;


    public UserRoleService(RoleManager<IdentityRole> roleManager, BlogDBContext blogDBContext)
    {
        _roleManager = roleManager;
        _blogDBContext = blogDBContext;
    }

    public async Task<IEnumerable<UserRoleListItemDto>> GetAllAsync()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        if (roles == null) throw new Exception();
        var roleList = roles.Select(r => new UserRoleListItemDto
        {
        RoleName=r.Name,
        UserName=r.Name
        }).ToList();

        return roleList;
    }


    public async Task CreateAsync(UserRoleCreateDto dto)
    {
        IdentityRole identity = new IdentityRole();
        await _blogDBContext.AddAsync(identity);
    }

    public async  Task Delete(int id)
    {
        if (id < 0 || id == null) throw new Exception();
        var entity =  _blogDBContext.Remove(id);
        if (entity != null) throw new ArgumentException();
        await _blogDBContext.SaveChangesAsync();

    }

    public Task UpdateAsync(UserRoleUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
