using BlogProject.Business.Exceptions.Role;
using BlogProject.Business.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Business.Services.Implements;

public class RoleService : IRoleService
{
    readonly RoleManager<IdentityRole> _roleManager;

    public RoleService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task CreateAsync(string name)
    {
       if(await _roleManager.RoleExistsAsync(name)) throw new RoleCreatedFailedException();
      var role =  await _roleManager.CreateAsync(new IdentityRole
       {
           Name = name  
       });
        if (!role.Succeeded)
        {
            string a="";
            foreach (var item in role.Errors)
            {
                a += item.Description = "";
            }
            throw new RoleNotFoundException(a);
        }
    }

    public async Task RemoveAsync(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role == null) throw new RoleNotFoundException();
       var result= await _roleManager.DeleteAsync(role);
        if(!result.Succeeded)
        {
            string a = String.Empty;
            foreach (var item in result.Errors)
            {
                a+= item.Description = "";
            }
            throw new RoleNotFoundException(a);
        }
    }

    public async Task<IEnumerable<IdentityRole>> GetAllAsync()
    {
        return await _roleManager.Roles.ToListAsync();
    }

    public async Task<string> GetByIdAsync(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role == null) throw new RoleNotFoundException();
        return role.Name;
    }

    public async Task  UpdateAsync(string id, string name)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role == null) throw new RoleNotFoundException();
        role.Name = name;
        var result = await _roleManager.UpdateAsync(role);
        if (!result.Succeeded)
        {
            var a = String.Empty;
            foreach (var item in result.Errors)
            {
                a += item.Description = "";
            }
            throw new RoleNotFoundException(a);
        }
    }
}
