using AutoMapper;
using BlogProject.Business.Dtos.UserAuthDtos;
using BlogProject.Business.Dtos.UserDtos;
using BlogProject.Business.Exceptions.Role;
using BlogProject.Business.Exceptions.User;
using BlogProject.Business.ExternalServices.Interfaces;
using BlogProject.Business.Services.Interfaces;
using BlogProject.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogProject.Business.Services.Implements;

public class UserService : IUserService
{
    readonly UserManager<AppUser> _userManager;
    readonly IMapper _mapper;
    readonly ITokenService _tokenService;
    readonly RoleManager<IdentityRole> _roleManager;

    public UserService(UserManager<AppUser> userManager, IMapper mapper, ITokenService tokenService, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _tokenService = tokenService;
        _roleManager = roleManager;
    }

    public async Task AddRoleAsync(string roleName, string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null) throw new UserExistException();
        if(!await _roleManager.RoleExistsAsync(roleName)) throw new RoleNotFoundException();
        var result = await _userManager.AddToRoleAsync(user, roleName);
        if (!result.Succeeded)
        {
            string a = "";
            foreach (var item in result.Errors)
            {
                a += item.Description = "";
            }
            throw new RoleCreatedFailedException(a);
        }
    }

    public async Task<ICollection<UserWithRoleDto>> GetAllAsync()
    {
        ICollection<UserWithRoleDto> users =  new List<UserWithRoleDto>();
        foreach (var user in await _userManager.Users.ToListAsync())
        {
            users.Add(new UserWithRoleDto
            {
                User=  _mapper.Map<AuthorDto>(user),
                Roles= await _userManager.GetRolesAsync(user),
            });
        }
        return users;
    }

    public async Task<TokenResponceDto> Login(LoginDto dto)
    {
        var user = await _userManager.FindByNameAsync(dto.UserName);
        if (user == null) throw new LoginFailedException("Username or password is not exist");
        var result = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (result == null) throw new LoginFailedException("Username is not exist");

        return _tokenService.CreateToken(user);
    }

    public async Task Register(RegisterDto dto)
    {
      var user = _mapper.Map<AppUser>(dto);
        if(await _userManager.Users.AnyAsync(u=>dto.UserName == user.UserName || dto.Email == u.Email ))
            throw new UserExistException();
        var result =   await _userManager.CreateAsync(user,dto.Password);
        if (!result.Succeeded)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in result.Errors)
            {
                sb.Append(item.Description + " ");
            }
            throw new UserFailedException(sb.ToString().TrimEnd());
        }
        
    }

    public Task RomoveRoleAsync(string roleName, string userName)
    {
        throw new NotImplementedException();
    }
}
