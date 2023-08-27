using AutoMapper;
using BlogProject.Business.Dtos.UserDtos;
using BlogProject.Business.Exceptions.User;
using BlogProject.Business.Services.Interfaces;
using BlogProject.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogProject.Business.Services.Implements;

public class UserService : IUserService
{
    readonly UserManager<AppUser> _userManager;
    readonly IMapper _mapper;
    readonly IConfiguration _configuration;

    public UserService(UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration)
    {
        _userManager = userManager;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<string> Login(LoginDto dto)
    {
        var user = await _userManager.FindByNameAsync(dto.UserName);
        if (user == null) throw new LoginFailedException("Username or password is not exist");
        var result = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (result == null) throw new LoginFailedException("Username is not exist");
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(ClaimTypes.NameIdentifier,user.Id)
    };
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));
        SigningCredentials signing = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
        JwtSecurityToken jwtSecurity = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audiance"]
            ,claims,DateTime.UtcNow,DateTime.UtcNow.AddMinutes(60),signing);
      JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
      string token=  securityTokenHandler.WriteToken(jwtSecurity);
        return token;
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
}
